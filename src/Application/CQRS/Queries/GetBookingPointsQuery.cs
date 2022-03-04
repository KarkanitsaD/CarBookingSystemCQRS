using DAL.Entities;
using DAL.Query;
using DAL.Query.FilterModels;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetBookingPointsQuery : IRequest<PageResult<BookingPointEntity>>
    {
        public GetBookingPointsQuery(BookingPointFilterModel bookingPointFilterModel)
        {
            BookingPointFilterModel = bookingPointFilterModel;
        }

        public BookingPointFilterModel BookingPointFilterModel { get; set; }
    }
}