using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpRinth.Builders
{
    /// <summary>
    /// Base class for the Builder Model
    /// </summary>
    /// <typeparam name="T">The type to return when executing the builder</typeparam>
    public abstract class BuilderBase<T>
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions serializerOptions;

        /// <summary>
        /// Creates a new instance of <see cref="BuilderBase{T}"/>
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient"/> to build with</param>
        protected BuilderBase(ModrinthClient client)
        {
            this.client = client.HttpClient;
            serializerOptions = client.SerializerOptions;
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="BuilderBase{T}"/>
        /// </summary>
        /// <returns>The builder result</returns>
        public abstract ExecuteResult<T> Execute();

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="BuilderBase{T}"/>
        /// </summary>
        /// <returns>The builder result</returns>
        public abstract Task<ExecuteResult<T>> ExecuteAsync();
    }
}
