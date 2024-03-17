using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace APItest
{

    [TestClass]
    public class RestApiTests
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
            var endpoint = "/posts/1";

            // Act
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PostMethod_CreatesResource()
        {
            // Arrange
            var endpoint = "/posts";
            var postData = new { title = "foo", body = "bar", userId = 1 };
            var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PutMethod_UpdatesResource()
        {
            // Arrange
            var endpoint = "/posts/1";
            var putData = new { id = 1, title = "foo", body = "bar", userId = 1 };
            var content = new StringContent(JsonConvert.SerializeObject(putData), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteMethod_DeletesResource()
        {
            // Arrange
            var endpoint = "/posts/1";

            // Act
            HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _httpClient.Dispose();
        }
    }

}