using System;
using System.IO;

namespace JSON_FROM_URL
{
    public class FileOperator
    {
        private readonly Logger log = Logger.GetLogger();

        public bool saveData(string data, string path)
        {
            try
            {
                if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(data)) 
                    return false;
                
                File.AppendAllText(path, data);
                File.AppendAllText(path, "\n");
                log.LogMessage("Saved json from api to file in path: " + path);
                return true;

            }
            catch (Exception e)
            {
                log.LogMessage("Occured error while saving json to output:", 4);
                Console.WriteLine(e);
                return false;
            }
        }
    }
}