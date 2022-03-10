using System;
using Application.Models.RequestModels;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateBookingPointCommand : IRequest<Guid>
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public Guid CityId { get; set; }

        public ExtraServiceCreateBookingPointRequestModel[] ExtraServices { get; set; }
    }
}