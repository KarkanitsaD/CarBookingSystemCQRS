using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using DAL.Entities;
using DAL.Query;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetBookingPointsQueryHandler : IRequestHandler<GetBookingPointsQuery, PageResult<BookingPointEntity>>
    {
        private readonly IBookingPointRepository _bookingPointRepository;

        public GetBookingPointsQueryHandler(IBookingPointRepository bookingPointRepository)
        {
            _bookingPointRepository = bookingPointRepository;
        }

        public async Task<PageResult<BookingPointEntity>> Handle(GetBookingPointsQuery request,
            CancellationToken cancellationToken)
        {
            return await _bookingPointRepository.GetPageListAsync(request.BookingPointFilterModel);
        }
    }
}