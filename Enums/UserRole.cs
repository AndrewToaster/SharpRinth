using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Enums
{
    /// <summary>
    /// Enumeration class describing the role of a user on Modrinth
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// The user is a Modrinth mod-developer
        /// </summary>
        Developer,

        /// <summary>
        /// The user is a Modrinth moderator
        /// </summary>
        Moderator,

        /// <summary>
        /// The user is a Modrinth admin
        /// </summary>
        Admin
    }
}
