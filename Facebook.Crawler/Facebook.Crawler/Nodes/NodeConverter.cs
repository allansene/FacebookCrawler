using Newtonsoft.Json.Converters;
using System;

namespace Facebook.Crawler
{
    public class PageNodeConverter : CustomCreationConverter<BaseNode>
    {
        public override BaseNode Create(Type objectType)
        {
            return new PageNode();
        }
    }

    public class PostNodeConverter : CustomCreationConverter<BaseNode>
    {
        public override BaseNode Create(Type objectType)
        {
            return new PostNode();
        }
    }
}
