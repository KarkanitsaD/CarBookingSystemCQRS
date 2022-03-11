using Application.Models.ResponseModels;
using Application.Models.ViewModels;
using DAL.Query.FilterModels;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetBookingsQuery : IRequest<PaginationResult<BookingViewModel>>
    {
        public BookingFilterModel Filter { get; set; }

        public GetBookingsQuery(BookingFilterModel filter)
        {
            Filter = filter;
        }
    }
}