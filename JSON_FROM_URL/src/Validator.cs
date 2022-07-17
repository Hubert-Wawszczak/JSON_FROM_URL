using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using JSON_FROM_URL.models;

namespace JSON_FROM_URL
{
    public class Validator : IValidator
    {
        public bool validateUrlFormat(string url)
        {
            if (url == null) return false;
            try
            {
                return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool validateUrlConnection(string url)
        {
            try
            {
                if (url == null) return false;
                var ping = new Ping();

                var result = ping.Send(url, 4000);

                if (result is not {Status: IPStatus.Success}) return false;

                var request = WebRequest.Create(url);
                request.Timeout = 4000;
                request.GetResponse();
                return true;
            }
            catch (TimeoutException te)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool validatorPathOrCreate(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }
    }
}