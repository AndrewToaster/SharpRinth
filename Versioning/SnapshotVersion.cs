using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    public struct SnapshotVersion : IGameVersion
    {
        /// <summary>
        /// The string of the version (e.g: 20w20a, 20w20b)
        /// </summary>
        public string VersionString { get; }

        private static readonly Regex _reg;

        static SnapshotVersion()
        {
            _reg = new(@"(\d+)w(\d+)([a-z])", RegexOptions.Compiled);
        }

        public SnapshotVersion(int majorVersion, int minorVersion, char iteration)
        {
            VersionString = $"{majorVersion}w{(minorVersion == 0 ? string.Empty : '.' + minorVersion)}{iteration}";
        }

        /// <summary>
        /// Parses a <see cref="SnapshotVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>(\d+)w(\d+)([a-z])</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <returns>Parsed <see cref="SnapshotVersion"/></returns>
        public static SnapshotVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), int.Parse(match.Groups[1].Value), match.Groups[0].Value[0]);
        }

        /// <summary>
        /// Tries to parse a <see cref="SnapshotVersion"/> from a string
        /// </summary>
        /// <remarks>
        /// Regex format: <c>(\d+)w(\d+)([a-z])</c>
        /// </remarks>
        /// <param name="input">The string to parse</param>
        /// <param name="version">The version if parsed; otherwise, default</param>
        /// <returns>Whether or not the parsing was successful</returns>
        public static bool TryParse(string input, out SnapshotVersion version)
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
