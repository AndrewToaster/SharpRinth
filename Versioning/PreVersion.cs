using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    public struct PreVersion : IGameVersion
    {
        public string VersionString { get; }
        private static readonly Regex _reg;

        static PreVersion()
        {
            _reg = new(@"1\.(\w+)(|\.\w+)-rc(\d+)", RegexOptions.Compiled);
        }

        public PreVersion(int majorVersion, int minorVersion, int iteration)
        {
            VersionString = $"1.{majorVersion}{(minorVersion == 0 ? string.Empty : $".{minorVersion}")}-pre{iteration}";
        }

        public static PreVersion Parse(string input)
        {
            Match match = _reg.Match(input);
            bool extra = match.Groups.Count == 3;
            int second = int.Parse(match.Groups[1].Value);

            return new(int.Parse(match.Groups[0].Value), extra ? second : 0, extra ? int.Parse(match.Groups[2].Value) : second);
        }

        public static bool TryParse(string input, out PreVersion version)
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
