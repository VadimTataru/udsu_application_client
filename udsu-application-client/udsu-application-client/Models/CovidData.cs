using Newtonsoft.Json;
using System;

namespace udsu_application_client.Models
{
    public class CovidData
    {
        [JsonProperty("Country")]
        public string CountryName { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Confirm")]
        public int Confirmed { get; set; }
        [JsonProperty("Recovered")]
        public int Recovered { get; set; }
        [JsonProperty("Deaths")]
        public int Deaths { get; set; }
    }
}
