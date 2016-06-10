using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class ResultBase<TEntity>: IResult
        where TEntity : class, INode
    {
        public virtual IList<BaseNode> data { get; set; }
        public Pagination paging { get; set; }
    }
}