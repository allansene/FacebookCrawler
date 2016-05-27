using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class SearchPageResult
    {
        public IList<No> data { get; set; }
        public Page paging { get; set; } 
    }
}
