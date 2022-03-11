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
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryEntity>>
    {
        private readonly ICountryRepository _countryRepository;

        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<CountryEntity>> Handle(GetAllCountriesQuery request,
            CancellationToken cancellationToken)
        {
            var countries = _countryRepository.GetAllCountries();

            return Task.FromResult(countries);
        }
    }
}