using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing a status of a mod
    /// </summary>
    public enum ModStatus
    {
        /// <summary>
        /// The status is unknown or invalid
        /// </summary>
        Unknown,

        /// <summary>
        /// Mod has been approved and shown to public
        /// </summary>
        Approved,

        /// <summary>
        /// Mod has been rejected
        /// </summary>
        Rejected,

        /// <summary>
        /// Mod is in a draft-state
        /// </summary>
        Draft,

        /// <summary>
        /// Mod is approved, but not shown to public
        /// </summary>
        Unlisted,

        /// <summary>
        /// Mod is still being processed
        /// </summary>
        Processing
    }
}
