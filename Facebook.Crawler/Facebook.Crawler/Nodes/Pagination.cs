using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class Pagination
    {
        public Cursors Cursors { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}