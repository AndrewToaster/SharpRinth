using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpRinth.Enums;

namespace SharpRinth
{
    internal static class Helper
    {
        public static HttpRequestMessage CreateRequest(this HttpClient client, string path, HttpMethod method)
        {
            return new HttpRequestMessage(method, client.BaseAddress.AbsoluteUri + path);
        }

        public static bool TryMatch(this Regex reg, string input, out Match match)
        {
            match = reg.Match(input);
            return match.Success;
        }

        public static async Task<(bool success, T result)> TryGetDeserialized<T>(this HttpClient client, string query, JsonSerializerOptions options)
        {
            HttpResponseMessage resp = await client.GetAsync(query).ConfigureAwait(false);
            if (resp.IsSuccessStatusCode)
            {
                try
                {
                    return (true, await JsonSerializer.DeserializeAsync<T>(await resp.Content.ReadAsStreamAsync().ConfigureAwait(false), options).ConfigureAwait(false));
                }
                catch (Exception ex) when (ex is JsonException or NotSupportedException)
                {
                    return (false, default);
                }
            }
            else
            {
                return (false, default);
            }
        }

        #region Enum ToString

        public static string GetEnumString(this SearchIndex @enum)
        {
            return @enum switch
            {
                SearchIndex.Relevance => "relevance",
                SearchIndex.DownloadCount => "downloads",
                SearchIndex.FollowCount => "follows",
                SearchIndex.RecentlyUpdated => "updated",
                SearchIndex.RecentlyAdded => "newest",
                _ => default,
            };
        }

        public static string GetEnumString(this SideDependence @enum)
        {
            return @enum switch
            {
                SideDependence.Optional => "optional",
                SideDependence.Required => "required",
                SideDependence.Unsupported => "unsupported",
                SideDependence.Unknown => "unknown",
                _ => "unknown",
            };
        }

        #endregion Enum ToString
    }
}
