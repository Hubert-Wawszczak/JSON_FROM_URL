using System;
using System.IO;

namespace JSON_FROM_URL
{
    public class FileOperator
    {
        public bool saveData(string data, string path)
        {
            try
            {
                File.AppendAllText(path, data);

                return true;
            }
            catch (Exception e)
            {
                
                return false;
            }
        }
    }
}