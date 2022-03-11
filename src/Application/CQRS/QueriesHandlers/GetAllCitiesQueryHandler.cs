using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Queries;
using AutoMapper;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.QueriesHandlers
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<CityEntity>>
    {
        private readonly ICityRepository _cityRepository;

        private readonly IMapper _mapper;

        public GetAllCitiesQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CityEntity>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = _cityRepository.GetAllCities();

            return Task.FromResult(cities);
        }
    }
}