using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpRinth.Exceptions;

namespace SharpRinth
{
    /// <summary>
    /// Structure to store Modrinth IDs
    /// </summary>
    public struct Identifier
    {
        /// <summary>
        /// The text representation of the identifier
        /// </summary>
        public string Id { get; }

        private static readonly Regex _reg;

        static Identifier()
        {
            _reg = new(@"^(?:|local-)([\w\d]{8})$", RegexOptions.Compiled);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Identifier"/>
        /// </summary>
        /// <remarks>
        /// This method can throw <see cref="InvalidIdException"/> if <paramref name="id"/> is malformed
        /// </remarks>
        /// <param name="id">The id to parse</param>
        public Identifier(string id)
        {
            if (_reg.TryMatch(id, out Match match))
            {
                Id = match.Captures[0].Value;
            }
            else
            {
                throw new InvalidIdException(id);
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
