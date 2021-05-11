using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRinth.MeiliSearch;

namespace SharpRinth.Filtering
{
    /// <summary>
    /// Complex search filter using MeiliSearch strings
    /// </summary>
    public sealed class ComplexFilter : ISearchFilter
    {
        public MeiliString Categories { get; set; }
        public MeiliString Versions { get; set; }
        public MeiliString License { get; set; }
        public MeiliString CreatedAt { get; set; }
        public MeiliString ModifiedAt { get; set; }
        public MeiliString ClientDependence { get; set; }
        public MeiliString ServerDependence { get; set; }
        public MeiliString FollowCount { get; set; }
        public MeiliString DownloadCount { get; set; }
        public MeiliString Name { get; set; }
        public MeiliString Author { get; set; }
        public MeiliString Description { get; set; }
        public MeiliString UrlSlug { get; set; }

        public override string ToString() => ToQueryString();

        /// <summary>
        /// Creates and returns a web-formatted query
        /// </summary>
        /// <returns>The query created</returns>
        public string ToQueryString()
        {
            StringBuilder builder = new();

            AppendString(Categories, builder);
            AppendString(Versions, builder);
            AppendString(License, builder);
            AppendString(CreatedAt, builder);
            AppendString(ModifiedAt, builder);
            AppendString(ClientDependence, builder);
            AppendString(ServerDependence, builder);
            AppendString(FollowCount, builder);
            AppendString(DownloadCount, builder);
            AppendString(Name, builder);
            AppendString(Author, builder);
            AppendString(Description, builder);
            AppendString(UrlSlug, builder);

            return builder.ToString();
        }

        private static void AppendString(MeiliString meiliString, StringBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(meiliString.Query))
                return;

            if (builder.Length > 0)
            {
                builder.Append(" AND ");
            }

            builder.Append('(').Append(meiliString.Query).Append(')');
        }
    }
}
