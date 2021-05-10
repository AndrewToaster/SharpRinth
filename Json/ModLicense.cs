using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpRinth.Json
{
    public sealed class ModLicense
    {
        [JsonPropertyName("id")]
        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
