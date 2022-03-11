using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateExtraServiceCommandHandler : IRequestHandler<CreateExtraServiceCommand, Guid>
    {
        private readonly IExtraServiceRepository _extraServiceRepository;

        public CreateExtraServiceCommandHandler(IExtraServiceRepository extraServiceRepository)
        {
            _extraServiceRepository = extraServiceRepository;
        }

        public async Task<Guid> Handle(CreateExtraServiceCommand request, CancellationToken cancellationToken)
        {
            var extraServiceEntity = new ExtraServiceEntity
            {
                Title = request.Title,
                Price = request.Price,
                IsAvailable = request.IsAvailable,
                MaximumAmountInBooking = request.MaximumAmountInBooking,
                BookingPointId = request.BookingPointId
            };

            extraServiceEntity = await _extraServiceRepository.CreateAsync(extraServiceEntity);

            return extraServiceEntity.Id;
        }
    }
}