using System;
using System.IO;

namespace JSON_FROM_URL
{
    public class Manager
    {
        private bool flag = false;
        private string[] _urls;

        private string PathToOutput { get; set; }

        private void SetUrls(string input)
        {
            var urls = input.Trim().Split(';');
            _urls = urls;
        }

        public void Run()
        {
            var valid = new Validator();
            var fileOp = new FileOperator();
            var urlFetcher = new UrlFetcher();

            Console.WriteLine("Give URL for fetch separate them with ;");
            SetUrls(Console.ReadLine()?.Trim());
            Console.WriteLine("Enter path to save output ");
            PathToOutput = Console.ReadLine()?.Trim();

            foreach (var url in _urls)
                if (valid.validateUrlFormat(url) && valid.validateUrlConnection(url) &&
                    valid.validatorPathOrCreate(PathToOutput))
                {
                    if (!flag)
                    {
                        PathToOutput = Path.Join(PathToOutput, "Output.json");
                        flag = true;
                    }

                    if (valid.FileExists(PathToOutput))
                    {
                        fileOp.saveData(urlFetcher.Get(url).ToString(), PathToOutput);
                    }
                    else
                    {
                        var file = File.CreateText(PathToOutput);
                        file.Close();
                        fileOp.saveData(urlFetcher.Get(url).ToString(), PathToOutput);
                    }
                }
        }
    }
}