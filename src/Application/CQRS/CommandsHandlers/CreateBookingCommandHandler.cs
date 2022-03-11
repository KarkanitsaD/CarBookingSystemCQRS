using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using Application.Models.RequestModels;
using AutoMapper;
using Business.Helpers;
using DAL;
using DAL.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly BookingPriceCalculatorHelper _priceCalculator;

        private readonly CarBookingSystemContext _context;

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(CarBookingSystemContext context, IHttpContextAccessor contextAccessor, BookingPriceCalculatorHelper priceCalculator, IMapper mapper)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _priceCalculator = priceCalculator;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == request.CarId, cancellationToken: cancellationToken);

            if (car == null)
            {
                //404
                throw new Exception();
            }

            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable, cancellationToken: cancellationToken);
            try
            {
                var bookingNumberOnGivenTime = await _context.Bookings
                    .CountAsync(GetBookingExistsExpression(
                        request.CarId,
                        request.PickUpTime,
                        request.HandOverTime),
                        cancellationToken);
                if (bookingNumberOnGivenTime > 0)
                {
                    throw new Exception();
                }

                var bookingPrice =
                    _priceCalculator.GetBookingPrice(request.PickUpTime, request.HandOverTime, car.PricePerDay);
                bookingPrice += await GetExtraServicePriceAsync(request.ExtraServices, car.BookingPointId);
                bookingPrice = Math.Round(bookingPrice, 2);

                var booking = _mapper.Map<CreateBookingCommand, BookingEntity>(request);
                booking.Price = bookingPrice;

                booking = (await _context.Bookings.AddAsync(booking, cancellationToken)).Entity;
                await _context.SaveChangesAsync(cancellationToken);

                await AddExtraServicesToBookingAsync(request.ExtraServices, booking.Id);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
                return booking.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        protected virtual Expression<Func<BookingEntity, bool>> GetBookingExistsExpression(Guid carId,
            DateTime pickUpTime, DateTime handOverTime)
        {
            return booking =>
                booking.CarId == carId &&
                !(booking.PickUpTime > pickUpTime && booking.PickUpTime > handOverTime ||
                  booking.HandOverTime < pickUpTime && booking.HandOverTime < handOverTime);
        }

        protected virtual async Task<decimal> GetExtraServicePriceAsync(ExtraServiceInBookingRequestModel[] extraServices, Guid bookingPointId )
        {
            var price = new decimal(0);
            foreach (var extraService in extraServices)
            {
                var serviceEntity =
                    await _context.ExtraServices.FirstOrDefaultAsync(s => s.Id == extraService.ExtraServiceId);

                if (serviceEntity == null ||
                    serviceEntity.BookingPointId != bookingPointId ||
                    serviceEntity.MaximumAmountInBooking > extraService.Amount ||
                    !serviceEntity.IsAvailable)
                {
                    throw new Exception(); //Bad request
                }

                price += _priceCalculator.GetExtraServicePrice(serviceEntity.Price, extraService.Amount);
            }

            return price;
        }

        private async Task AddExtraServicesToBookingAsync(ExtraServiceInBookingRequestModel[] extraServices, Guid bookingId)
        {
            var extraServicesBooking = new List<ExtraServiceBookingEntity>();
            foreach (var service in extraServices)
            {
                var extraServiceBooking = new ExtraServiceBookingEntity
                {
                    ExtraServiceId = service.ExtraServiceId,
                    Amount = service.Amount,
                    BookingId = bookingId
                };

                extraServicesBooking.Add(extraServiceBooking);
            }
            await _context.ExtraServiceBookings.AddRangeAsync(extraServicesBooking);
        }
    }
}