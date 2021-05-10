using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing side dependence
    /// </summary>
    public enum SideDependence
    {
        /// <summary>
        /// Describes that the dependence is not known
        /// </summary>
        Unknown,

        /// <summary>
        /// Describes that the mod may be used on the side
        /// </summary>
        Optional,

        /// <summary>
        /// Describes that the mod must be used on the side
        /// </summary>
        Required,

        /// <summary>
        /// Describes that the mod must not be used on the side
        /// </summary>
        Unsupported
    }
}
