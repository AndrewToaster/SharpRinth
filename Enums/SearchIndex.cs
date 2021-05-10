using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing how to index mods in a search
    /// </summary>
    public enum SearchIndex
    {
        /// <summary>
        /// Mods are indexed using their relevance
        /// </summary>
        Relevance,

        /// <summary>
        /// Mods are indexed using their download count
        /// </summary>
        DownloadCount,

        /// <summary>
        /// Mods are indexed using their follower count
        /// </summary>
        FollowCount,

        /// <summary>
        /// Mods are indexed using their update date
        /// </summary>
        RecentlyUpdated,

        /// <summary>
        /// Mods are indexed using their upload date
        /// </summary>
        RecentlyAdded,
    }
}
