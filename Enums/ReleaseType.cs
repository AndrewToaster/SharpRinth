using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing the release type of a mod
    /// </summary>
    public enum ReleaseType
    {
        /// <summary>
        /// The mod is released and stable
        /// </summary>
        Release,

        /// <summary>
        /// The mod is still being tested and might be unstable
        /// </summary>
        Beta,

        /// <summary>
        /// The mod is not tested and will most likely unstable
        /// </summary>
        Alpha
    }
}
