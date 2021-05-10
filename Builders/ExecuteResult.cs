using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRinth.Builders
{
    /// <summary>
    /// Structure used by <see cref="BuilderBase{T}"/> to output results
    /// </summary>
    /// <typeparam name="T">The type of the result</typeparam>
    public struct ExecuteResult<T>
    {
        /// <summary>
        /// Indicates whether or not this <see cref="ExecuteResult{T}"/> was successful and contains a proper <see cref="Result"/>
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Contains the result of this <see cref="ExecuteResult{T}"/>
        /// </summary>
        /// <value>
        /// If <see cref="Success"/> then actual result; otherwise, <see langword="default"/>(<typeparamref name="T"/>)
        /// </value>
        public T Result { get; }

        /// <summary>
        /// Creates a new instance of <see cref="ExecuteResult{T}"/> with a specified <paramref name="result"/>
        /// and <paramref name="success"/>
        /// </summary>
        /// <param name="result">The result to set</param>
        /// <param name="success">Whether or not this result is successful</param>
        public ExecuteResult(T result, bool success)
        {
            Result = result;
            Success = success;
        }

        /*
        /// <summary>
        /// Returns a successful <see cref="ExecuteResult{T}"/> with its result set to <paramref name="result"/>
        /// </summary>
        /// <param name="result">The result to set</param>
        public static ExecuteResult<T> Success(T result) => new(result, true);

        /// <summary>
        /// Returns a unsuccessful <see cref="ExecuteResult{T}"/> with its result set to <see langword="default"/>(<typeparamref name="T"/>)
        /// </summary>
        public static ExecuteResult<T> Fail() => new(default, true);
        */
    }

    /// <summary>
    /// Structure containing static methods for outputting <see cref="ExecuteResult{T}"/>s
    /// </summary>
    public struct ExecuteResult
    {
        // Make this not constructible
        private readonly int __;

        // Make this not constructible
        private ExecuteResult(int _)
        {
            __ = _;
        }

        /// <summary>
        /// Returns a successful <see cref="ExecuteResult{T}"/> with its result set to <paramref name="result"/>
        /// </summary>
        /// <param name="result">The result to set</param>
        public static ExecuteResult<T> Success<T>(T result) => new(result, true);

        /// <summary>
        /// Returns a unsuccessful <see cref="ExecuteResult{T}"/> with its result set to <see langword="default"/>(<typeparamref name="T"/>)
        /// </summary>
        public static ExecuteResult<T> Fail<T>() => new(default, true);
    }
}
