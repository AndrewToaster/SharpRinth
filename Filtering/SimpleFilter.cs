using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRinth.Enums;
using SharpRinth.MeiliSearch;
using SharpRinth.Versioning;

namespace SharpRinth.Filtering
{
    public sealed class SimpleFilter : ISearchFilter
    {
        public SideDependence ServerDependence { get; set; }
        public SideDependence ClientDependence { get; set; }

        public List<IGameVersion> Versions { get; set; }
        public List<ModCategory> Categories { get; set; }

        public SimpleFilter()
        {
            ServerDependence = SideDependence.Unknown;
            ClientDependence = SideDependence.Unknown;
            Versions = new();
            Categories = new();
        }

        public override string ToString()
        {
            return ToQueryString();
        }

        public string ToQueryString()
        {
            StringBuilder builder = new();

            if (ServerDependence != SideDependence.Unknown)
            {
                AppendMeili(ServerDependence.ToString(), MeiliBuilder.TOKEN_SERVER_SIDE_DEPENDENCE, builder);
            }

            if (ClientDependence != SideDependence.Unknown)
            {
                AppendMeili(ClientDependence.ToString(), MeiliBuilder.TOKEN_CLIENT_SIDE_DEPENDENCE, builder);
            }

            if (Versions.Count != 0)
            {
                MeiliBuilder mBuilder = new(MeiliBuilder.TOKEN_VERSION);
                for (int i = 0; i < Versions.Count; i++)
                {
                    if (i > 0)
                    {
                        mBuilder.Or();
                    }
                    mBuilder.Value(Versions[i].VersionString);
                }

                AppendString(mBuilder.Build(), builder);
            }

            if (Categories.Count != 0)
            {
                MeiliBuilder mBuilder = new(MeiliBuilder.TOKEN_CATEGORY);
                for (int i = 0; i < Versions.Count; i++)
                {
                    if (i > 0)
                    {
                        mBuilder.And();
                    }
                    mBuilder.Value(Categories[i].ToString());
                }

                AppendString(mBuilder.Build(), builder);
            }

            return builder.ToString();
        }

        private static void AppendMeili(string str, string token, StringBuilder builder)
        {
            AppendString(MeiliString.ConvertToMeili(str, token), builder);
        }

        private static void AppendString(string str, StringBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(str))
                return;

            if (builder.Length > 0)
            {
                builder.Append(" AND ");
            }

            builder.Append('(').Append(str).Append(')');
        }
    }
}
