using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using SharpRinth.Json;
using SharpRinth.Utility;

namespace SharpRinth.Builders
{
    public sealed class ReleasesSearchRequestBuilder : IdBuilderBase<ModRelease[]>
    {
        /// <summary>
        /// Creates a new instance of <see cref="ReleasesSearchRequestBuilder" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        public ReleasesSearchRequestBuilder(ModrinthClient client, Identifier id) : base(client, id)
        {
        }

        /// <summary>
        /// Sets the <see cref="IdBuilderBase{T}.Identifier"/> value
        /// </summary>
        /// <param name="id">The identifier to set</param>
        /// <returns>Current <see cref="ReleasesSearchRequestBuilder"/></returns>
        public new ReleasesSearchRequestBuilder WithIdentifier(Identifier id)
        {
            return (ReleasesSearchRequestBuilder)base.WithIdentifier(id);
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="ReleasesSearchRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override ExecuteResult<ModRelease[]> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="ReleasesSearchRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override async Task<ExecuteResult<ModRelease[]>> ExecuteAsync()
        {
            var result = await client.TryGetDeserialized<ModRelease[]>($"mod/{Identifier}/version", serializerOptions).ConfigureAwait(false);
            return new ExecuteResult<ModRelease[]>(result.result, result.success);
        }
    }
}
