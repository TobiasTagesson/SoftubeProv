using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSoftube.Models
{
    public class Result
    {
        public string id { get; set; }
        public string name { get; set; }
        // public string fullProductId { get; set; }
        // public string demoProductId { get; set; }
        // public string featureHighlight { get; set; }
        // public string url { get; set; }
        // public bool notSoldOnWebsite { get; set; }
        // public string description { get; set; }
        // public bool hasDemo { get; set; }
        // public bool isHardwareProduct { get; set; }
        // public bool isInStock { get; set; }
        // public List<string> ecoSystems { get; set; }
        //// public string[] EcoSystems { get; set; }
        // public List<Price> price { get; set; }
        public Images images { get; set; }


    }

    public class Price
    {
        public string campaign { get; set; }
        public string normal { get; set; }
        public double campaignDecimal { get; set; }
        public double normalDecimal { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("240w")]
        public string w240 { get; set; }

        [JsonPropertyName("480w")]
        public string w480 { get; set; }

        [JsonPropertyName("640w")]
        public string w640 { get; set; }
    }
}

