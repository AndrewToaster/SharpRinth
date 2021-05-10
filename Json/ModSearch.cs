using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpRinth.Json
{
    /// <summary>
    /// Contains data about a mod search
    /// </summary>
    public sealed class ModSearch
    {
        [JsonPropertyName("hits")]
        public ModHit[] Results { get; set; }

        [JsonPropertyName("offset")]
        public int SearchOffset { get; set; }

        [JsonPropertyName("limit")]
        public int SearchCount { get; set; }

        [JsonPropertyName("total_hits")]
        public int TotalSearchResults { get; set; }
    }
}
