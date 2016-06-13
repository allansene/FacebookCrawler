﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Facebook.Crawler
{
    public class FacebookService
    {
        private FacebookClient _fbClient;

        private GlobalIO _io = new GlobalIO();

        private JsonSerializerSettings _settings;

        public enum SEARCH_TYPE
        {
            user,
            page,
            @event, //escaping the keyword event
            group
        }

        public FacebookService(string access_token)
        {
            _fbClient = this.InitFacebookClient(access_token);
            _settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }

        private FacebookClient InitFacebookClient(string access_token)
        {
            var _fb = new FacebookClient();
            try
            {
                //access_token = "EAACEdEose0cBAEw1EbihQvNZAZBEZAVHilhmCVF3ukzIHI15cIFZBW4Pj0hOAw3flKIZBgfkefoRPm3ujXK9UdKobhxhB3wkfwudHoxtqUeuuIzncK6GZAi3a8nnLlZAc3wfNa4QmZBJjYK9JrAxWSlXJTAQjbZBQGZCTkZBiaSLZASceZC5soEYlyZAaxsIBBTcfi3dcZD";
                _fb.AccessToken = access_token;

                return _fb;
            }
            catch
            {

            }

            return _fb;
        }

        public IResult ProcessSearchQuery(string query, SEARCH_TYPE type)
        {
            IResult result = null;
            query = "search?q=" + query;
            try
            {
                //var pages = _fbClient.Get("search?q=spotted+ufmg&type=page").ToString();

                switch (type)
                {
                    case SEARCH_TYPE.user:
                        var users = _fbClient.Get(query + "&type=" + type.ToString()).ToString();
                        result = JsonConvert.DeserializeObject<ResultBase<BaseNode>>(users, _settings);
                        break;
                    case SEARCH_TYPE.page:
                        var pages = _fbClient.Get(query + "&type=" + type.ToString()).ToString();
                        result = JsonConvert.DeserializeObject<ResultBase<PageNode>>(pages, new PageNodeConverter());
                        break;
                    case SEARCH_TYPE.@event:
                        var events = _fbClient.Get(query + "&type=" + type.ToString()).ToString();
                        result = JsonConvert.DeserializeObject<ResultBase<BaseNode>>(events, _settings);
                        break;
                    case SEARCH_TYPE.group:
                        var groups = _fbClient.Get(query + "&type=" + type.ToString()).ToString();
                        result = JsonConvert.DeserializeObject<ResultBase<BaseNode>>(groups, _settings);
                        break;
                    default:
                        var pages2 = _fbClient.Get(query + "&type=" + type.ToString()).ToString();
                        result = JsonConvert.DeserializeObject<ResultBase<PageNode>>(pages2, _settings);
                        break;
                }

            }
            catch
            {
                throw;
            }

            return result;
        }

        public void CrawlIntoPages(IResult pages, string pathToFile)
        {

            string lastGet = string.Empty;
            
            try
            {
                int count = 0;
                foreach (var page in pages.data)
                {
                    lastGet = page.Id + "/feed";
                    var feedsTxt = _fbClient.Get("" + page.Id + "/feed").ToString();
                    var pageFeed = JsonConvert.DeserializeObject<ResultBase<PostNode>>(feedsTxt, new PostNodeConverter());
                    while (pageFeed.paging != null | pageFeed.paging.Next != null)
                    {
                        lastGet = pageFeed.paging.Next;
                        feedsTxt = _fbClient.Get(pageFeed.paging.Next).ToString();
                        pageFeed = JsonConvert.DeserializeObject<ResultBase<PostNode>>(feedsTxt, new PostNodeConverter());
                        foreach (var post in pageFeed.data)
                        {
                            _io.WriteJson(JsonConvert.SerializeObject(post, _settings), pathToFile);
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

    }
}
