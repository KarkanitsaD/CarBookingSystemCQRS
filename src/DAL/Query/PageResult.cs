using System.Collections.Generic;

namespace DAL.Query
{
    public class PageResult<TEntity>
    {
        public IEnumerable<TEntity> Items { get; set; }

        public int ItemsTotalCount { get; set; }
    }
}
