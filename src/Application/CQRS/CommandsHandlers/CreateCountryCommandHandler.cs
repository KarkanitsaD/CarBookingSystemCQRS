using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Commands;
using AutoMapper;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using MediatR;

namespace Application.CQRS.CommandsHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<CreateCountryCommand, CountryEntity>(request);

            var entity = await _countryRepository.CreateAsync(country);

            return entity.Id;
        }
    }
}