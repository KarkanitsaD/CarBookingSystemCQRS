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
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly ICityRepository _cityRepository;

        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var cityEntity = _mapper.Map<CreateCityCommand, CityEntity>(request);

            var city  = await _cityRepository.CreateAsync(cityEntity);

            return city.Id;
        }
    }
}