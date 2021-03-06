using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.MeiliSearch
{
    /// <summary>
    /// Helper class for building MeiliSearch queries
    /// </summary>
    public sealed class MeiliBuilder
    {
        #region Tokens

        /// <summary>
        /// Token for filtering by categories
        /// </summary>
        /// <remarks>
        /// Use <see cref="Enums.ModCategory"/> for values
        /// </remarks>
        public const string TOKEN_CATEGORY = "categories";

        /// <summary>
        /// Token for filtering by versions
        /// </summary>
        /// <remarks>
        /// Use <see cref="Versioning.IGameVersion.VersionString"/> for values
        /// </remarks>
        public const string TOKEN_VERSION = "versions";

        /// <summary>
        /// Token for filtering by licenses
        /// </summary>
        /// <remarks>
        /// Use <see cref="Json.ModLicense.Identifier"/> for values
        /// </remarks>
        public const string TOKEN_LICENSE = "license";

        /// <summary>
        /// Token for filtering by creation date
        /// </summary>
        /// <remarks>
        /// Use <see cref="Utility.DateTimeRFC3339.FromDateTime(DateTime)"/> for values
        /// </remarks>
        public const string TOKEN_CREATED_AT = "date_created";

        /// <summary>
        /// Token for filtering by modification date
        /// </summary>
        /// <remarks>
        /// Use <see cref="Utility.DateTimeRFC3339.FromDateTime(DateTime)"/> for values
        /// </remarks>
        public const string TOKEN_MODIFIED_AT = "date_modified";

        /// <summary>
        /// Token for filtering by client-side dependence
        /// </summary>
        /// <remarks>
        /// Use <see cref="Enums.SideDependence"/> for values
        /// </remarks>
        public const string TOKEN_CLIENT_SIDE_DEPENDENCE = "client_side";

        /// <summary>
        /// Token for filtering by server-side dependence
        /// </summary>
        /// <remarks>
        /// Use <see cref="Enums.SideDependence"/> for values
        /// </remarks>
        public const string TOKEN_SERVER_SIDE_DEPENDENCE = "server_side";

        /// <summary>
        /// Token for filtering by follower count
        /// </summary>
        /// <remarks>
        /// Use <see cref="Enums.SideDependence"/> for values
        /// </remarks>
        public const string TOKEN_FOLLOW_COUNT = "follows";

        /// <summary>
        /// Token for filtering by download count
        /// </summary>
        /// <remarks>
        /// Use <see cref="Enums.SideDependence"/> for values
        /// </remarks>
        public const string TOKEN_DOWNLOAD_COUNT = "downloads";

        /// <summary>
        /// Token for filtering by names
        /// </summary>
        /// <remarks>
        /// Use <see cref="Json.Mod.Name"/> for values
        /// </remarks>
        public const string TOKEN_TITLE = "title";

        /// <summary>
        /// Token for filtering by authors
        /// </summary>
        public const string TOKEN_AUTHOR = "author";

        /// <summary>
        /// Token for filtering by descriptions
        /// </summary>
        /// <remarks>
        /// Use <see cref="Json.Mod.Description"/> for values
        /// </remarks>
        public const string TOKEN_DESCRIPTION = "description";

        /// <summary>
        /// Token for filtering by categories
        /// </summary>
        /// <remarks>
        /// Use <see cref="Json.Mod.UrlSlug"/> for values
        /// </remarks>
        public const string TOKEN_URL_SLUG = "slug";

        #endregion Tokens

        private readonly StringBuilder _builder;
        private readonly string _token;

        /// <summary>
        /// Creates a new instance of <see cref="MeiliBuilder"/> using a specified <paramref name="meiliToken"/>
        /// </summary>
        /// <param name="meiliToken"></param>
        public MeiliBuilder(string meiliToken)
        {
            _builder = new();
            _token = meiliToken;
        }

        /// <summary>
        /// Appends a 'AND' logical operator
        /// </summary>
        public MeiliBuilder And()
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
        public MeiliBuilder Value(string value)
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
        public MeiliBuilder Value<T>(T value)
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
        public MeiliGroup<MeiliBuilder> Group()
        {
            _builder.Append(" (");
            return new MeiliGroup<MeiliBuilder>(this, _token, _builder);
        }

        /// <summary>
        /// Appends a 'OR' logical operator
        /// </summary>
        public MeiliBuilder Or()
        {
            _builder.Append(" OR");
            return this;
        }

        /// <summary>
        /// Appends a 'NOT' logical operator
        /// </summary>
        public MeiliBuilder Not()
        {
            _builder.Append(" NOT");
            return this;
        }

        /// <summary>
        /// Builds a new <see cref="MeiliString"/> from input
        /// </summary>
        public MeiliString Build()
        {
            return new(_builder.ToString()[1..]);
        }
    }
}
