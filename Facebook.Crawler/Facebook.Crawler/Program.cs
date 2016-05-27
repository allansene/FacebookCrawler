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
            try
            {
                //string access_token = "EAACEdEose0cBAHnmJ4ZAKhoZA9kCwtX4pMK2qYW3Ngbno6kJeBmvbN6Mo3JnDOEZBN5KkkAnngQWXa25ZCAz0oD1hMFn1kg8kC3PmGXqRWljEnQeUeHNXK6mE5c1AuBurnAbN8716zPKQDvZAE5ARq6aZB2ilm8iqqX9Dew0huGdOMCj4CCmmo";
                var _fb = new FacebookClient();
                FacebookOAuthResult oauthResult;

                
                dynamic parameters = new ExpandoObject();
                parameters.client_id = "1596455934002644";
                parameters.response_type = "token";
                parameters.display = "page";


                var extendedPermissions = "user_likes,user_friends";
                parameters.scope = extendedPermissions;
                Uri uri = _fb.GetLoginUrl(parameters);
                //_fb.AccessToken = access_token;

                var oauthValid = _fb.TryParseOAuthCallbackUrl(uri, out oauthResult);
                parameters.client_secret = "589bde7fbe33850dd8846151d847520b";
                parameters.code = oauthResult.Code;

                dynamic result = _fb.Get("/oauth/access_token", parameters);
                
                _fb.AccessToken = result.access_token;

                var retorno = _fb.Get("search?q=spotted+ufmg&type=page").ToString();

                SearchPageResult spottedUFMGPages = JsonConvert.DeserializeObject<SearchPageResult>(retorno);

                foreach (No page in spottedUFMGPages.data)
                {
                    var retorno2 = _fb.Get("" + page.Id + "/feed").ToString();
                    string feeds = null;
                    Console.Write(retorno2);
                }

                File.WriteAllText(@"D:\fb.json", retorno);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
