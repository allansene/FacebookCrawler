using System;
using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class CommentResult
    {
        public IList<CommentNode> data { get; set; }
        public Pagination paging { get; set; }
    }
}