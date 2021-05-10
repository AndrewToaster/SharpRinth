using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpRinth.Json
{
    public sealed class ReleaseFile
    {
        public FileHashMap Hashes { get; set; }

        [JsonPropertyName("url")]
        public string DownloadUrl { get; set; }

        public string FileName { get; set; }

        public bool Primary { get; set; }
    }
}
