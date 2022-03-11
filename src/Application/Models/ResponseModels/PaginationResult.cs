using System.Collections.Generic;

namespace Application.Models.ResponseModels
{
    public class PaginationResult<TResponseModel> where TResponseModel : class
    {
        public List<TResponseModel> Items { get; set; }
        
        public int ItemsTotalCount { get; set; }
    }
}