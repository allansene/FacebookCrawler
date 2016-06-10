using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Crawler
{
    public class PostNode
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime created_time { get; set; }
        public LikesResult Likes { get; set; }
        public CommentResult Comments { get; set; }
    }
}
