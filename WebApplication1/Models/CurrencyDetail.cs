using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class CurrencyDetail
    {
        [JsonProperty("Alış")]
        public string Alis { get; set; }
        [JsonProperty("Satış")]
        public string Satis { get; set; }
        [JsonProperty("Değişim")]
        public string Degisim { get; set; }
    }
}
