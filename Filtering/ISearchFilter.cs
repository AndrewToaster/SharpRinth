using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Filtering
{
    public interface ISearchFilter
    {
        string ToQueryString();
    }
}
