using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    /// <summary>
    /// Version structure using the release-candidate (RC) format
    /// </summary>
    public struct RCVersion : IGameVersion
    {
        /// <summary>
        /// The string of the version (e.g: 1.16-rc1, 1.16.2-rc2)
        /// </summary>
        public string VersionString { get; }

        private static readonly Regex _reg;

        static RCVersion()
        {
            _reg = new(@"1\.(\w+)(|\.\w+)-rc(\d+)", RegexOptions.Compiled);
        }

        public RCVersion(int version, int iteration)
        {
            VersionString = $"1.{version}-rc{iteration}";
        }

        /// <summary>
        /// Parses a <see cref="RCVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>1\.(\w+)(|\.\w+)-rc(\d+)</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <returns>Parsed <see cref="RCVersion"/></returns>
        public static RCVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), int.Parse(match.Groups[1].Value));
        }

        /// <summary>
        /// Tries to parse a <see cref="RCVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>1\.(\w+)(|\.\w+)-rc(\d+)</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <param name="version">The version if parsed; otherwise, default</param>
        /// <returns>Whether or not the parsing was successful</returns>
        public static bool TryParse(string input, out RCVersion version)
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
