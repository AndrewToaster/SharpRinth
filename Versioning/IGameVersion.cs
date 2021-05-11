using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Versioning
{
    /// <summary>
    /// Common interface for game versions
    /// </summary>
    public interface IGameVersion
    {
        /// <summary>
        /// The string of the version (e.g: 1.16.5, 1.16-rc1)
        /// </summary>
        string VersionString { get; }
    }
}
