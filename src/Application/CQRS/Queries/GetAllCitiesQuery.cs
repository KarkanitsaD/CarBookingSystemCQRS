using System.Collections.Generic;
using DAL.Entities;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<CityEntity>>
    {
        
    }
}