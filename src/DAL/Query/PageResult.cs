using System.Collections.Generic;

namespace DAL.Query
{
    public class PageResult<TEntity>
    {
        public List<TEntity> Items { get; set; }

        public int ItemsTotalCount { get; set; }
    }
}
