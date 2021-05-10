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

        public static SnapshotVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), int.Parse(match.Groups[1].Value), match.Groups[0].Value[0]);
        }

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
