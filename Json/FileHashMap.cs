using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpRinth.Json
{
    public sealed class FileHashMap
    {
        [JsonPropertyName("sha1")]
        public string Sha1Hash { get; set; }

        [JsonPropertyName("sha512")]
        public string Sha512Hash { get; set; }
    }
}
