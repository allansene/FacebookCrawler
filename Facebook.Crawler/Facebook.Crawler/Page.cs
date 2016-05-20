using System.Collections.Generic;

namespace Facebook.Crawler
{
    public class Page
    {
        public Cursors Cursors { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}