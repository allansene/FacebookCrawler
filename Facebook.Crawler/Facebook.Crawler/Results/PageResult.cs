using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class PageResult
    {
        public IList<PageNode> data { get; set; }
        public Pagination paging { get; set; } 
    }
}
