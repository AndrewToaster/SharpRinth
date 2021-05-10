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
    public sealed class UserRequestBuilder : IdBuilderBase<ModrinthUser>
    {
        /// <summary>
        /// Creates a new instance of <see cref="UserRequestBuilder" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        public UserRequestBuilder(ModrinthClient client, Identifier id) : base(client, id)
        {
        }

        /// <summary>
        /// Sets the <see cref="IdBuilderBase{T}.Identifier"/> value
        /// </summary>
        /// <param name="id">The identifier to set</param>
        /// <returns>Current <see cref="UserRequestBuilder"/></returns>
        public new UserRequestBuilder WithIdentifier(Identifier id)
        {
            return (UserRequestBuilder)base.WithIdentifier(id);
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="UserRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override ExecuteResult<ModrinthUser> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="UserRequestBuilder" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override async Task<ExecuteResult<ModrinthUser>> ExecuteAsync()
        {
            var result = await client.TryGetDeserialized<ModrinthUser>($"user/{Identifier}", serializerOptions).ConfigureAwait(false);
            return new ExecuteResult<ModrinthUser>(result.result, result.success);
        }
    }
}
