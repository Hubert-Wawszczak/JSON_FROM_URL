using System;
using System.IO;
using System.Net;
using JSON_FROM_URL.models;

namespace JSON_FROM_URL
{
    public class Validator : IValidator
    {
        private readonly Logger log = Logger.GetLogger();

        public bool validateUrlFormat(string url)
        {
            if (url == null) return false;
            try
            {
                return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            }
            catch (Exception e)
            {
                log.LogMessage("Url is not in the correct format or occured error:");
                Console.WriteLine(e);
                return false;
            }
        }

        public bool validateUrlConnection(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    var request = WebRequest.Create(url);
                    request.Timeout = 4000;
                    request.GetResponse();
                    return true;
                }
                
            }
            catch (TimeoutException te)
            {
                log.LogMessage("Timeout Url is not available or occured error:");
                Console.WriteLine(te);
                return false;
            }
            catch (Exception e)
            {
                log.LogMessage("Url is not available or occured error:");
                Console.WriteLine(e);
                return false;
            }

            return false;
        }

        public bool validatorPathOrCreate(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    log.LogMessage("Created directory: " + path);
                    Directory.CreateDirectory(path);
                    return true;
                }
            }
            catch (IOException ie)
            {
                log.LogMessage("Directory exist in path: " + path);
                return true;
            }
            catch (Exception e)
            {
                log.LogMessage("Occured error with creating directory: ", 4);
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool FileExists(string path)
        {
            if (File.Exists(path))
                return true;
            return false;
        }
    }
}