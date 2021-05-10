using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    public struct RCVersion : IGameVersion
    {
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

        public static RCVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            return new(int.Parse(match.Groups[0].Value), int.Parse(match.Groups[1].Value));
        }

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
