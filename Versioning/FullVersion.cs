using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SharpRinth.Versioning
{
    /// <summary>
    /// Version structure using the full-release format
    /// </summary>
    public struct FullVersion : IGameVersion
    {
        /// <summary>
        /// The string of the version (e.g: 1.16, 1.16.4)
        /// </summary>
        public string VersionString { get; }

        private static readonly Regex _reg;

        static FullVersion()
        {
            _reg = new(@"1\.(\w+)(|\.\w+)", RegexOptions.Compiled);
        }

        public FullVersion(int majorVersion, int minorVersion)
        {
            VersionString = $"1.{majorVersion}{(minorVersion == 0 ? string.Empty : $".{minorVersion}")}";
        }

        /// <summary>
        /// Parses a <see cref="FullVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>1\.(\w+)(|\.\w+)</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <returns>Parsed <see cref="FullVersion"/></returns>
        public static FullVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), match.Groups.Count == 2 ? int.Parse(match.Groups[1].Value) : 0);
        }

        /// <summary>
        /// Tries to parse a <see cref="FullVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>1\.(\w+)(|\.\w+)</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <param name="version">The version if parsed; otherwise, default</param>
        /// <returns>Whether or not the parsing was successful</returns>
        public static bool TryParse(string input, out FullVersion version)
        {
            if (CanParse(input))
            {
                version = Parse(input);
                return true;
            }
            else
            {
                version = default;
                return false;
            }
        }

        public override string ToString()
        {
            return VersionString;
        }

        internal static bool CanParse(string input)
        {
            return _reg.IsMatch(input);
        }
    }
}
