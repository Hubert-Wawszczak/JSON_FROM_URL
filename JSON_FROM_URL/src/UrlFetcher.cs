using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace JSON_FROM_URL
{
    public class UrlFetcher
    {
        public string Get(string apiUri)
        {
            var json = new WebClient().DownloadString(apiUri);
            return json;
        }
    }
}