using System.Collections.Generic;

namespace Facebook.Crawler
{
    public interface IResult
    {
        IList<BaseNode> data { get; set; }
        Pagination paging { get; set; }
    }
}
