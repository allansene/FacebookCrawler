using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Crawler
{
    public class SearchPageResult
    {
        public IList<No> data { get; set; }
        public Page paging { get; set; } 
    }
}
