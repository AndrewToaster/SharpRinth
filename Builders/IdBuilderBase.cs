using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Builders
{
    public abstract class IdBuilderBase<T> : BuilderBase<T>
    {
        public Identifier Identifier { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="IdBuilderBase{T}" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        protected IdBuilderBase(ModrinthClient client, Identifier id) : base(client)
        {
            Identifier = id;
        }

        /// <summary>
        /// Sets the <see cref="Identifier"/> value
        /// </summary>
        /// <param name="id">The identifier to use</param>
        /// <returns>Current <see cref="ReleaseRequestBuilder"/></returns>
        public IdBuilderBase<T> WithIdentifier(Identifier id)
        {
            Identifier = id;
            return this;
        }
    }
}
