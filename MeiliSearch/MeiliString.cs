using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.MeiliSearch
{
    /// <summary>
    /// Structure for MeiliSearch queries
    /// </summary>
    public struct MeiliString
    {
        /// <summary>
        /// The MeiliSearch query string
        /// </summary>
        public string Query { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MeiliString"/>
        /// </summary>
        /// <param name="query">The query to use</param>
        public MeiliString(string query)
        {
            Query = query;
        }

        /// <summary>
        /// Helper method for creating MeiliSearch value operator
        /// </summary>
        /// <param name="text">The text to query with</param>
        /// <param name="token">The token which to match <paramref name="text"/> with</param>
        /// <returns>Formatted string</returns>
        public static string ConvertToMeili(string text, string token)
        {
            return $"{token}=\"{text}\"";
        }

        public static explicit operator MeiliString(string str)
        {
            return new(str);
        }

        public static implicit operator string(MeiliString meiliStr)
        {
            return meiliStr.Query;
        }

        public override string ToString()
        {
            return Query;
        }
    }
}
