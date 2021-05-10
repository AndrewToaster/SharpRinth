using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SharpRinth.Enums;

namespace SharpRinth.Json
{
    public sealed class ModrinthUser
    {
        [JsonPropertyName("id")]
        public Identifier Identifier { get; set; }

        [JsonPropertyName("github_id")]
        public ulong GithubId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("avatar_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("created")]
        public DateTime RegisteredAt { get; set; }

        public string Bio { get; set; }

        public UserRole Role { get; set; }
    }
}
