using System.Linq;
using System.Text;

namespace SharpRinth.MeiliSearch
{
    /// <summary>
    /// MeiliSearch group builder
    /// </summary>
    /// <typeparam name="TParent">The parent to return when finishing a group</typeparam>
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

        /// <summary>
        /// Appends a 'AND' logical operator
        /// </summary>
        public MeiliGroup<TParent> And()
        {
            _builder.Append(" AND");
            return this;
        }

        /// <summary>
        /// Appends a selector operator
        /// </summary>
        /// <remarks>
        /// Operator syntax: <c>token="value"</c>
        /// </remarks>
        /// <param name="value">The value to match</param>
        public MeiliGroup<TParent> Value(string value)
        {
            _builder.Append(' ').Append(_token).Append("=\"").Append(value).Append('"');
            return this;
        }

        /// <summary>
        /// Appends a selector operator
        /// </summary>
        /// <remarks>
        /// Operator syntax: <c>token="value"</c>
        /// </remarks>
        /// <param name="value">The value to match</param>
        public MeiliGroup<TParent> Value<T>(T value)
        {
            _builder.Append(' ').Append(_token).Append("=\"").Append(value).Append('"');
            return this;
        }

        /// <summary>
        /// Appends a group
        /// </summary>
        /// <remarks>
        /// Operator syntax: <c>token="value"</c>
        /// </remarks>
        /// <returns>A builder for a group</returns>
        public MeiliGroup<MeiliGroup<TParent>> Group()
        {
            _builder.Append(" (");
            return new MeiliGroup<MeiliGroup<TParent>>(this, _token, _builder);
        }

        /// <summary>
        /// Appends a 'OR' logical operator
        /// </summary>
        public MeiliGroup<TParent> Or()
        {
            _builder.Append(" OR");
            return this;
        }

        /// <summary>
        /// Appends a 'NOT' logical operator
        /// </summary>
        public MeiliGroup<TParent> Not()
        {
            _builder.Append(" NOT");
            return this;
        }

        /// <summary>
        /// Finishes a group and returns the inner parent
        /// </summary>
        public TParent BuildGroup()
        {
            _builder.Append(')');
            return _parent;
        }
    }
}
