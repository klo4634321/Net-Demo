using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class PredictionResult
    {
        [JsonProperty("class_id")]
        public int ClassId { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

}
