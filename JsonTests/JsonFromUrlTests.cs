using System.IO;
using JSON_FROM_URL;
using Xunit;

namespace JsonTests
{
    public class JsonTests
    {
        private readonly UrlFetcher _fetcher;
        private readonly Manager _manager;
        private readonly FileOperator _operator;
        private readonly Validator _validator;
        private const string _path = @"D:\Repo\C#\JSON_FROM_URL\JsonTests\TestDir";

        public JsonTests()
        {
            _operator = new FileOperator();
            _manager = new Manager();
            _fetcher = new UrlFetcher();
            _validator = new Validator();
        }

        [Fact]
        public void FileExistTest1()
        {
            Assert.True(_validator.FileExists(Path.Join(_path, "FileTest.json")));
        }

        [Fact]
        public void FileExistTest2()
        {
            Assert.False(_validator.FileExists(Path.Join(_path, "FileTest2.json")));
        }

        [Fact]
        public void ValidateUrlTest1()
        {
            Assert.True(_validator.validateUrlFormat(
                "https://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest2()
        {
            Assert.False(_validator.validateUrlFormat(
                "https://apim.weatherapi.com24@%()_++!@#C/v1/#$#[]'';'current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest3()
        {
            Assert.True(_validator.validateUrlConnection(
                "https://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest4()
        {
            Assert.False(_validator.validateUrlConnection(
                "https://apim.weatherapi.com24@%()_++!@#C/v1/#$#[]'';'current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void FileOperatorTest1()
        {
            _operator.saveData("test", Path.Join(_path, "FileTest.json"));
            var lines = File.ReadAllLines(Path.Join(_path, "FileTest.json"));
            File.WriteAllText(Path.Join(_path, "FileTest.json"), string.Empty);
            Assert.Equal("test", lines[0]);
        }

        [Fact]
        public void UrlGetTest1()
        {
            var json = _fetcher.Get(
                "https://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no");
            Assert.Contains("Warszawa", json);
        }

        [Fact]
        public void UrlGetTest2()
        {
            var json = _fetcher.Get(
                "https://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no");
            Assert.DoesNotContain("hab", json);
        }
    }
}