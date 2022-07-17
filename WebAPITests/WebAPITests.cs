using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace UnitTests
{
    public class WebAPITests
    {
        readonly IHostBuilder _client;

        public WebAPITests(TESTING_API.Program application)
        {
            String[] args = new String[]{};
            _client = application.CreateHostBuilder(args);
        }

        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            var response = await _client.;
            response.Run();
            response.
        }
    }
    }
}