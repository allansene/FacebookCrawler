namespace Facebook.Crawler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new FacebookService("EAACEdEose0cBAEptZBEXkYjFKgPjwIzBPq7AT4IQ78SYUprk2VGB2qwUqL0DT22Lc9PaZAc8gTT2JGt6O1pqziHrOSEh7quGYZAJL9g2W6KZAcvIlfZAFZCD52Oa5mOlEa46fxZC31BmHPsNZCOieX4qPnVjXTQZBzrSRzYYCDqjd8C834ZBZC2ldJDQklqYBDXoZB8ZD");
            var result = client.ProcessSearchQuery("spotted+ufmg", FacebookService.SEARCH_TYPE.page);
            client.CrawlIntoPages(result, "D:\\fb_posts.json");
        }
    }
}
