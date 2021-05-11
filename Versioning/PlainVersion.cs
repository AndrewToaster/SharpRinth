using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    /// <summary>
    /// Plain non-formatted version structure
    /// </summary>
    public struct PlainVersion : IGameVersion
    {
        public string VersionString { get; }

        /// <summary>
        /// Creates a new instance of <see cref="PlainVersion"/>
        /// </summary>
        /// <param name="text"></param>
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
