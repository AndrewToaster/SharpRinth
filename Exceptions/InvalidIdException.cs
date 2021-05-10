using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Exceptions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1194:Implement exception constructors.", Justification = "No, I don't think i will")]
    public sealed class InvalidIdException : Exception
    {
        public InvalidIdException(string id) : base($"The id '{id}' has invalid format")
        {
        }
    }
}
