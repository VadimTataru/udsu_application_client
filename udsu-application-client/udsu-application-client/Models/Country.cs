using Newtonsoft.Json;

namespace udsu_application_client.Models
{
    public class Country
    {
        [JsonProperty("countryName")]
        public string Name { get; set; }
    }
}
