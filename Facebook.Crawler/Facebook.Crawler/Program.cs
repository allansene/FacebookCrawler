using System;
using System.Collections.Generic;
using System.Dynamic;
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
            string app_id = "1596455934002644";
            string app_secret = "589bde7fbe33850dd8846151d847520b";
            string access_token = "EAACEdEose0cBADEyWAlbLiGLZAjULkCGCOhdC5X8fpE5ubQJbOlIsZAnBsa6JaiXuJr6K1My769wimc4DsxghTjHErQkkhKidgHuzukunfikwqSmfGmpzmWrDptczA9pBjj1j0pXa64tsXhizCf5rns1cfkgBwVVj2O0G7GQZDZD";

            var _fb = new FacebookClient();
            _fb.AccessToken = access_token;
            _fb.Version = "v2.6";
            var retorno = _fb.Get("1592515421013351?fields=feed{message,comments}");

        }
    }
}
