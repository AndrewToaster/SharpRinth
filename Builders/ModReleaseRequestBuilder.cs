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
    public sealed class ReleaseRequestBuilder : IdBuilderBase<ModRelease>
    {
        /// <summary>
        /// Creates a new instance of <see cref="ReleaseRequestBuilder" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        public ReleaseRequestBuilder(ModrinthClient client, Identifier id) : base(client, id)
        {
        }

        /// <summary>
        /// Sets the <see cref="IdBuilderBase{T}.Identifier"/> value
        /// </summary>
        /// <param name="id">The identifier to set</param>
        /// <returns>Current <see cref="ReleaseRequestBuilder"/></returns>
        public new ReleaseRequestBuilder WithIdentifier(Identifier id)
        {
            return (ReleaseRequestBuilder)base.WithIdentifier(id);
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="ReleaseRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override ExecuteResult<ModRelease> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="ReleaseRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override async Task<ExecuteResult<ModRelease>> ExecuteAsync()
        {
            var result = await client.TryGetDeserialized<ModRelease>($"version/{Identifier}", serializerOptions).ConfigureAwait(false);
            return new ExecuteResult<ModRelease>(result.result, result.success);
        }
    }
}
