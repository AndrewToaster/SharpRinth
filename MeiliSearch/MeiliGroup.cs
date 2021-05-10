using System.Linq;
using System.Text;

namespace SharpRinth.MeiliSearch
{
    public class MeiliGroup<TParent>
    {
        private readonly TParent _parent;
        private readonly StringBuilder _builder;
        private readonly string _token;

        internal MeiliGroup(TParent parent, string token, StringBuilder stringBuilder)
        {
            _parent = parent;
            _builder = stringBuilder;
            _token = token;
        }

        public MeiliGroup<TParent> And()
        {
            _builder.Append(" AND");
            return this;
        }

        public MeiliGroup<TParent> Value(string value)
        {
            _builder.Append(' ').Append(_token).Append("=\"").Append(value).Append('"');
            return this;
        }

        public MeiliGroup<MeiliGroup<TParent>> Group()
        {
            _builder.Append(" (");
            return new MeiliGroup<MeiliGroup<TParent>>(this, _token, _builder);
        }

        public MeiliGroup<TParent> Or()
        {
            _builder.Append(" OR");
            return this;
        }

        public MeiliGroup<TParent> Not()
        {
            _builder.Append(" NOT");
            return this;
        }

        public TParent BuildGroup()
        {
            _builder.Append(')');
            return _parent;
        }
    }
}
