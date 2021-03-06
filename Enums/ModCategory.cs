using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing mod categories for a mod search
    /// </summary>
    public enum ModCategory
    {
        Technology,
        Adventure,
        Magic,
        Utility,
        Decoration,
        Library,
        Cursed,
        WorldGeneration,
        Storage,
        Food,
        Equipment,
        Miscellaneous,

        /// <summary>
        /// 'Fabric' means the FabricMC mod-loader
        /// </summary>
        Fabric,

        /// <summary>
        /// 'Forge' means the Forge mod-loader
        /// </summary>
        Forge
    }
}
