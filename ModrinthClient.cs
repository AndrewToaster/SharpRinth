using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SharpRinth.Builders;

namespace SharpRinth
{
    /// <summary>
    /// Main class for interacting with the Modrinth API
    /// </summary>
    public sealed class ModrinthClient : IDisposable
    {
        internal HttpClient HttpClient { get; }
        internal JsonSerializerOptions SerializerOptions { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ModrinthClient"/> using the Modrinth V1 API
        /// </summary>
        public ModrinthClient()
        {
            HttpClient = new();
            {
                HttpClient.BaseAddress = new Uri("https://api.modrinth.com/api/v1/");
            }

            SerializerOptions = new(JsonSerializerDefaults.General)
            {
                PropertyNameCaseInsensitive = true
            };
            SerializerOptions.Converters.Add(new Converters.SideEnumConverter());
            SerializerOptions.Converters.Add(new Converters.CategoryEnumConverter());
            SerializerOptions.Converters.Add(new Converters.GameVersionConverter());
            SerializerOptions.Converters.Add(new Converters.StatusEnumConverter());
            SerializerOptions.Converters.Add(new Converters.ReleaseTypeConverter());
            SerializerOptions.Converters.Add(new Converters.ModrinthIdConverter());
        }

        ~ModrinthClient()
        {
            Dispose();
        }

        /// <summary>
        /// Returns a new <see cref="ModSearchRequestBuilder"/> for building a search query
        /// </summary>
        public ModSearchRequestBuilder SearchMods()
        {
            return new(this);
        }

        /// <summary>
        /// Returns a new <see cref="ModIdRequestBuilder"/> for building a mod id search query
        /// </summary>
        /// <param name="modId">The default id to set</param>
        public ModIdRequestBuilder GetMod(Identifier modId = default)
        {
            return new(this, modId);
        }

        /// <summary>
        /// Returns a new <see cref="UserRequestBuilder"/> for building a mod id search query
        /// </summary>
        /// <param name="userId">The default id to set</param>
        public UserRequestBuilder GetUser(Identifier userId = default)
        {
            return new(this, userId);
        }

        /// <summary>
        /// Returns a new <see cref="ReleasesSearchRequestBuilder"/> for building a mod id search query
        /// </summary>
        /// <param name="modId">The default id to set</param>
        public ReleasesSearchRequestBuilder GetReleases(Identifier modId = default)
        {
            return new(this, modId);
        }

        /// <summary>
        /// Returns a new <see cref="ReleaseRequestBuilder"/> for building a mod id search query
        /// </summary>
        /// <param name="releaseId">The default id to set</param>
        public ReleaseRequestBuilder GetRelease(Identifier releaseId = default)
        {
            return new(this, releaseId);
        }

        /// <summary>
        /// Disposes the inner <see cref="HttpClient"/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            HttpClient.Dispose();
        }
    }
}
