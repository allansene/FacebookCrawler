using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class LikesResult
    {
        public IList<LikeNode> data { get; set; }
        public Pagination paging { get; set; }
    }
}