namespace JSON_FROM_URL
{
    public class Manager
    {
        private string[] _urls;

        public string PathToOutput { get; set; }

        public void SetUrls(string input)
        {
            var urls = input.Trim().Split(';');
            _urls = urls;
        }

        public string[] GetUrls()
        {
            return _urls;
        }

        public void run()
        {
        }
    }
}