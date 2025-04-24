using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class ResNetApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        // 構造函數，從 IConfiguration 讀取設定
        public ResNetApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ResNetApi:Url"]; // 讀取設定檔中的 API URL
            _httpClient.BaseAddress = new Uri(_apiUrl); // 設置 HttpClient 的 BaseAddress
        }

        public async Task<PredictionResult> SendImageForPredictionAsync(IFormFile imageFile)
        {
            using var content = new MultipartFormDataContent();
            using var stream = imageFile.OpenReadStream();
            var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

            content.Add(streamContent, "file", imageFile.FileName);

            var response = await _httpClient.PostAsync("/predict", content); // 使用相對路徑 "/predict"
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var predictionResult = JsonConvert.DeserializeObject<PredictionResult>(jsonResponse); // 解析 JSON 字串

            return predictionResult;
        }
    }
}
