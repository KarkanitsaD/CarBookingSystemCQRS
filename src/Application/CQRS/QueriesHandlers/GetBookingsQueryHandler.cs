using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using Application.Models.ResponseModels;
using Application.Models.ViewModels;
using AutoMapper;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, PaginationResult<BookingViewModel>>
    {
        private readonly IBookingRepository _repository;

        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BookingViewModel>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var pageResult = await _repository.GetPageListAsync(request.Filter);

            var viewModels = _mapper.Map<List<BookingEntity>, List<BookingViewModel>>(pageResult.Items);

            return new PaginationResult<BookingViewModel>
            { Items = viewModels, ItemsTotalCount = pageResult.ItemsTotalCount };
        }
    }
}