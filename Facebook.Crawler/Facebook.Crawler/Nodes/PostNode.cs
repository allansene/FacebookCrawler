using System;

namespace Facebook.Crawler
{
    public class PostNode : BaseNode
    {
        public string Message { get; set; }
        public DateTime created_time { get; set; }
        public ResultBase<LikeNode> Likes { get; set; }
        public ResultBase<CommentNode> Comments { get; set; }
    }
}
