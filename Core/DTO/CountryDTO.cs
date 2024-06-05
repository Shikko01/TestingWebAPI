﻿using Newtonsoft.Json;

namespace Core.DTO
{
    public class CountryDTO
    {
        [JsonProperty("country_id")]
        public string CountryId { get; set; }
        public double Probability { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
