using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.MeiliSearch
{
    public struct MeiliString
    {
        public string Query { get; }

        public MeiliString(string query)
        {
            Query = query;
        }

        public static string ConvertToMeili(string text, string token)
        {
            return $"{token}=\"{text}\"";
        }

        public static explicit operator MeiliString(string str)
        {
            return new(str);
        }

        public static implicit operator string(MeiliString meiliStr)
        {
            return meiliStr.Query;
        }

        public override string ToString()
        {
            return Query;
        }
    }
}
