using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
namespace Facebook.Crawler
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var client = new FacebookService("");
            var result = client.ProcessSearchQuery("spotted+ufmg", FacebookService.SEARCH_TYPE.page);
            client.CrawlIntoPages(result, "D:\\fb_posts.json");
        }

        
    }
}
