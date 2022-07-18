using System;
using System.IO;

namespace JSON_FROM_URL
{
    public class Manager
    {
        private bool _flag;

        private string[] _urls;
        private Logger log;
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
            SetUrls(Console.ReadLine()?.Trim().Replace("\r", "").Replace("\r", ""));
            Console.WriteLine("Enter path to save output ");
            PathToOutput = Console.ReadLine()?.Trim();

            log = Logger.GetLogger();

            foreach (var url in _urls)
                if (valid.validateUrlFormat(url) && valid.validateUrlConnection(url) &&
                    valid.validatorPathOrCreate(PathToOutput))
                {
                    if (!_flag)
                    {
                        PathToOutput = Path.Join(PathToOutput, "Output.json");
                        _flag = true;
                    }

                    if (valid.FileExists(PathToOutput))
                    {
                        fileOp.saveData(urlFetcher.Get(url), PathToOutput);
                    }
                    else
                    {
                        if (PathToOutput != null)
                        {
                            var file = File.CreateText(PathToOutput);
                            file.Close();
                        }

                        fileOp.saveData(urlFetcher.Get(url), PathToOutput);
                    }
                }
        }
    }
}