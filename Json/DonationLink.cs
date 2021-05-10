using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpRinth.Json
{
    public sealed class DonationLink
    {
        public string Id { get; set; }

        [JsonPropertyName("platform")]
        public string PlatformName { get; set; }

        public string Url { get; set; }
    }
}
