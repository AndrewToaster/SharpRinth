using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SharpRinth.Versioning
{
    public struct FullVersion : IGameVersion
    {
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

        public static FullVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), match.Groups.Count == 2 ? int.Parse(match.Groups[1].Value) : 0);
        }

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
