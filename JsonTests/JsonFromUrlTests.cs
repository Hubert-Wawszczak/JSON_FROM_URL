using System;
using System.IO;
using System.Linq;
using JSON_FROM_URL;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JsonTests
{
    public class JsonTests
    {
        private string _path = @"D:\Repo\C#\JSON_FROM_URL\JsonTests\TestDir";
        private readonly FileOperator _operator;
        private readonly Manager _manager;
        private readonly UrlFetcher _fetcher;
        private readonly Validator _validator;

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
                "http://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest2()
        {
            Assert.False(_validator.validateUrlFormat(
                "http://apim.weatherapi.com24@%()_++!@#C/v1/#$#[]'';'current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest3()
        {
            Assert.True(_validator.validateUrlConnection(
                "http://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
        }

        [Fact]
        public void ValidateUrlTest4()
        {
            Assert.False(_validator.validateUrlConnection(
                "http://apim.weatherapi.com24@%()_++!@#C/v1/#$#[]'';'current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no"));
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
        public void UrlGetTest()
        {
            var json = _fetcher.Get(
                "https://api.weatherapi.com/v1/current.json?key=b15affaf6ace42bfb67192328221707&q=Warszawa&aqi=no");
            Assert.True(json.Contains("Warszawa"));
        }
    }
}