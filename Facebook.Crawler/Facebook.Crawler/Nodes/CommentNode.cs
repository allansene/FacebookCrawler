using System;

namespace Facebook.Crawler
{
    public class CommentNode
    {
        public string Id { get; set; }
        public From from { get; set; }
        public string Message { get; set; }
        public DateTime created_time { get; set; }
        public int like_count { get; set; }
    }
}