namespace JSON_FROM_URL.models
{
    public interface IValidator
    {
        public bool validateUrlFormat(string url);
        public bool validateUrlConnection(string url);

        public bool validatorPathOrCreate(string path);
    }
}