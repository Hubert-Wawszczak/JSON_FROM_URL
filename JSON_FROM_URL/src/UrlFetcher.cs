using System;
using System.Diagnostics;
using System.Net.Http;

namespace JSON_FROM_URL
{
    public class UrlFetcher
    {
        public Uri Get(string apiUri)
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponseMessage = httpClient.GetAsync(apiUri).Result;
                Debug.Assert(httpResponseMessage.RequestMessage != null, "httpResponseMessage.RequestMessage != null");
                return httpResponseMessage.RequestMessage.RequestUri;
            }
        }
    }
}