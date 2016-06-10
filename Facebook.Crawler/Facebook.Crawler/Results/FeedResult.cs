using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class FeedResult
    {
        public IList<PostNode> data { get; set; }
        public Pagination paging { get; set; } 
    }
}
