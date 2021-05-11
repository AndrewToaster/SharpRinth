using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Filtering
{
    /// <summary>
    /// Common interface for creating search filters
    /// </summary>
    public interface ISearchFilter
    {
        /// <summary>
        /// Creates and returns a web-formatted query
        /// </summary>
        /// <returns>The query created</returns>
        string ToQueryString();
    }
}
