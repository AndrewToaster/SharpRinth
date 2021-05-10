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
    public sealed class ModIdRequestBuilder : IdBuilderBase<Mod>
    {
        /// <summary>
        /// Creates a new instance of <see cref="ModIdRequestBuilder" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        public ModIdRequestBuilder(ModrinthClient client, Identifier id) : base(client, id)
        {
        }

        /// <summary>
        /// Sets the <see cref="IdBuilderBase{T}.Identifier"/> value
        /// </summary>
        /// <param name="id">The identifier to set</param>
        /// <returns>Current <see cref="ModIdRequestBuilder"/></returns>
        public new ModIdRequestBuilder WithIdentifier(Identifier id)
        {
            return (ModIdRequestBuilder)base.WithIdentifier(id);
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="ModIdRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override ExecuteResult<Mod> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="ModIdRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override async Task<ExecuteResult<Mod>> ExecuteAsync()
        {
            var result = await client.TryGetDeserialized<Mod>($"mod/{Identifier}", serializerOptions).ConfigureAwait(false);
            return new ExecuteResult<Mod>(result.result, result.success);
        }
    }
}
