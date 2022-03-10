using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateBookingPointCommandHandler : IRequestHandler<CreateBookingPointCommand, Guid>
    {
        private readonly IBookingPointRepository _bookingPointRepository;

        private readonly IExtraServiceRepository _extraServiceRepository;

        public CreateBookingPointCommandHandler(IBookingPointRepository bookingPointRepository, IExtraServiceRepository extraServiceRepository)
        {
            _bookingPointRepository = bookingPointRepository;
            _extraServiceRepository = extraServiceRepository;
        }

        public async Task<Guid> Handle(CreateBookingPointCommand request, CancellationToken cancellationToken)
        {
            var bookingPointEntity = new BookingPointEntity
            {
                Address = request.Address,
                CityId = request.CityId,
                Title = request.Title
            };

            bookingPointEntity = await _bookingPointRepository.CreateAsync(bookingPointEntity);

            var extraServices = new ExtraServiceEntity[request.ExtraServices.Length];
            for (int i = 0; i < request.ExtraServices.Length; i++)
            {
                var service = request.ExtraServices[i];
                extraServices[i] = new ExtraServiceEntity
                {
                    Title = service.Title,
                    Price = service.Price,
                    IsAvailable = service.IsAvailable,
                    MaximumAmountInBooking = service.MaximumAmountInBooking,
                    BookingPointId = bookingPointEntity.Id
                };
            }

            await _extraServiceRepository.CreateRangeAsync(extraServices);

            return bookingPointEntity.Id;
        }
    }
}