using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APItest
{
 

    [TestClass]
    public class ApiTests
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        [TestInitialize]
        public void Initialize()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        [TestMethod]
        public async Task GetMethod_ReturnsSuccess()
        {
            // Arrange
            var endpoint = "/posts/1"; // Example endpoint from JSONPlaceholder API

            // Act
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Optionally, you can also verify the content of the response
            string responseBody = await response.Content.ReadAsStringAsync();
            // Add assertions for response content if needed
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient.Dispose();
        }
    }

}
