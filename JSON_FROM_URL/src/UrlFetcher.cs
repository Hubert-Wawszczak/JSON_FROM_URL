using System;
using System.Net;

namespace JSON_FROM_URL
{
    public class UrlFetcher
    {
        private readonly Logger log = Logger.GetLogger();

        public string Get(string apiUri)
        {
            try
            {
                var json = new WebClient().DownloadString(apiUri);
                log.LogMessage("Downloaded json from: " + apiUri);
                return json;
            }
            catch (System.Net.WebException we)
            {   
                log.LogMessage("Something wrong occured during fetching data",4);
                Console.WriteLine(we);
                return null;
            }
            catch (Exception e)
            {
                log.LogMessage("Something wrong occured during fetching data",4);
                Console.WriteLine(e);
                return null;
            }
        }
    }
}