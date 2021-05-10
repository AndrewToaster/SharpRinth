using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    public struct PlainVersion : IGameVersion
    {
        public string VersionString { get; }

        public PlainVersion(string text)
        {
            VersionString = text;
        }

        public override string ToString()
        {
            return VersionString;
        }
    }
}
