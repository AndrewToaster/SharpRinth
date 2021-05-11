using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharpRinth.Utility
{
    internal class QueryBuilder
    {
        private readonly StringBuilder _builder;
        private int _qCount;

        public QueryBuilder(string initialString)
        {
            _builder = new(initialString);
            _qCount = 0;
        }

        public QueryBuilder AddQuery(string name, object value)
        {
            _builder.Append(_qCount++ > 0 ? "&" : "?").Append(name).Append('=').Append(HttpUtility.HtmlEncode(value?.ToString()));
            return this;
        }

        public QueryBuilder AddQueryCondicional(bool condition, string name, object value)
        {
            if (condition)
                AddQuery(name, value);

            return this;
        }

        public QueryBuilder AddQueryNonEmpty(string name, object value)
        {
            string q = HttpUtility.UrlEncode(value?.ToString());
            if (!string.IsNullOrWhiteSpace(q))
                _builder.Append(_qCount++ > 0 ? "&" : "?").Append(name).Append('=').Append(q);

            return this;
        }

        public string Build()
        {
            return _builder.ToString();
        }
    }
}
