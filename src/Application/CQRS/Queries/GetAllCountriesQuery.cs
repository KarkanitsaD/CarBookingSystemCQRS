using System.Collections.Generic;
using DAL.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryEntity>>
    {
        
    }
}