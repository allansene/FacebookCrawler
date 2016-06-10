using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Crawler
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetFacebookLoginUrl();
        }
        public static void GetFacebookLoginUrl()
        {
            string lastGet = string.Empty;
            try
            {
                string access_token = "EAACEdEose0cBAEw1EbihQvNZAZBEZAVHilhmCVF3ukzIHI15cIFZBW4Pj0hOAw3flKIZBgfkefoRPm3ujXK9UdKobhxhB3wkfwudHoxtqUeuuIzncK6GZAi3a8nnLlZAc3wfNa4QmZBJjYK9JrAxWSlXJTAQjbZBQGZCTkZBiaSLZASceZC5soEYlyZAaxsIBBTcfi3dcZD";
                var _fb = new FacebookClient();

                _fb.AccessToken = access_token;

                var pages = _fb.Get("search?q=spotted+ufmg&type=page").ToString();
                PageResult spottedUFMGPages = JsonConvert.DeserializeObject<PageResult>(pages);

                File.WriteAllText(@"D:\\fb_pages.json", pages);

                string path = "D:\\fb_posts.json";
                int count = 0;
                foreach (var page in spottedUFMGPages.data)
                {
                    lastGet = page.Id + "/feed";
                    var feedsTxt = _fb.Get("" + page.Id + "/feed").ToString();
                    var pageFeed = JsonConvert.DeserializeObject<FeedResult>(feedsTxt);
                    while (pageFeed.paging != null | pageFeed.paging.Next != null)
                    {
                        lastGet = pageFeed.paging.Next;
                        feedsTxt = _fb.Get(pageFeed.paging.Next).ToString();
                        pageFeed = JsonConvert.DeserializeObject<FeedResult>(feedsTxt);
                        foreach (var post in pageFeed.data)
                        {
                            EscreveJson(JsonConvert.SerializeObject(post), path);
                            Console.WriteLine(count++);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Last Get:" + lastGet);
                throw;
            }

        }

        private static void EscreveJson(string json, string path)
        {

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(json);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(json);
            }
        }
    }
}
