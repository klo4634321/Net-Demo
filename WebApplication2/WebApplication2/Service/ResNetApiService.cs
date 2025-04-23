using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApplication2.Service
{
    public class ResNetApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ResNetApiService(HttpClient httpClient, string apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl;
            _httpClient.BaseAddress = new Uri("http://localhost:8000"); // FastAPI server URL
        }

        public async Task<string> SendImageForPredictionAsync(IFormFile imageFile)
        {
            using var content = new MultipartFormDataContent();
            using var stream = imageFile.OpenReadStream();
            var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

            content.Add(streamContent, "file", imageFile.FileName);

            var response = await _httpClient.PostAsync("/predict", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }

}
