using Newtonsoft.Json;
using System.Collections.Generic;

namespace Session3Assignment.DataModels
{
    /// <summary>
    /// User JSON Model
    /// </summary>
    public class PetJsonModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrls")]
        public string[] PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Tags[] Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Tags
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TagsComparer : IEqualityComparer<Tags>
    {
        public bool Equals(Tags x, Tags y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Tags x)
        {
            return x.Id.GetHashCode();
        }
    }
}
