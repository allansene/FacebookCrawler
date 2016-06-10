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
                string access_token = "EAACEdEose0cBAHZBsPcAGGc9YX2ZC0kJxEKfihdPB8esYsAAbIvX4jtOZCHg9moLvYk4Vekz3Jfup06kexD5m2ncrb1ypsPEvDjt1ObbjBVTrlauPnBoQhHkiwieMxbzQvOfdSRK82OxJpKqFK9bqavppAwIo7KPnYuXPuDgMyUflLohLcTgunC0qqSgZBAZD";
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
                    EscreveJson(feedsTxt,path);
                    while (pageFeed.paging.Next != null)
                    {
                        lastGet = pageFeed.paging.Next;
                        feedsTxt = _fb.Get(pageFeed.paging.Next).ToString();
                        pageFeed = JsonConvert.DeserializeObject<FeedResult>(feedsTxt);
                        EscreveJson(feedsTxt, path);
                        Console.WriteLine( count++);
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
