namespace DevIct.PublicMeetings.Back.Data
{
    /// <summary>
    /// Represents the results of a Data operation that does not return a value.
    /// </summary>
    public class DataResult
    {
        /// <summary>
        /// Initializes a <see cref="DataResult"/>.
        /// </summary>
        /// <param name="success">
        /// Whether the data operation was successful or not.
        /// </param>
        /// <param name="errors">
        /// The errors that occurred to make the operation fail.
        /// </param>
        protected internal DataResult(bool success, DataError[]? errors = null)
        {
            Succeeded = success;
            Errors = success ? new DataError[0] : errors ?? new DataError[0];
        }

        /// <summary>
        /// Gets whether the data operation was successful or not.
        /// </summary>
        public bool Succeeded { get; }

        /// <summary>
        /// Gets the errors that occurred during the operation.
        /// </summary>
        /// <remarks>
        /// If <see cref="Succeeded"/> is true, this will be an empty array.
        /// </remarks>
        public DataError[] Errors { get; }

        /// <summary>
        /// Creates a new <see cref="DataResult"/> for a successful operation.
        /// </summary>
        internal static DataResult Success => new DataResult(true);

        /// <summary>
        /// Creates a new <see cref="DataResult"/> for a failed operation.
        /// </summary>
        /// <param name="errors"/>
        /// The <see cref="DataError"/>s that occured.
        /// </param>
        internal static DataResult Failure(params DataError[] errors)
        {
            return new DataResult(false, errors);
        }
    }

    /// <summary>
    /// Represents the results of a data operation that returns a value if successful.
    /// </summary>
    /// <typeparam name="TResult">
    /// The type of the result the data operation returns.
    /// </typeparam>
    public abstract class DataResult<TResult> : DataResult
    {
        private DataResult(bool success, DataError[]? errors = null) : base(success, errors)
        {
        }

        /// <summary>
        /// Gets the result of the data operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"/>
        /// Thrown when trying to access the result of a failed operation.
        /// </exception>
        public abstract TResult GetResult();

        /// <summary>
        /// Creates a new <see cref="DataResult{TResult}"/> for a successful operation.
        /// </summary>
        /// <param name="result">
        /// The result of the operation.
        /// </param>
        internal static new DataResult<TResult> Success(TResult result)
        {
            return new SuccessfulResult(result);
        }

        /// <summary>
        /// Creates a new <see cref="DataResult{TResult}"/> for a failed operation.
        /// </summary>
        /// <param name="errors"/>
        /// The <see cref="DataError"/>s that occured.
        /// </param>
        internal static new DataResult<TResult> Failure(params DataError[] errors)
        {
            return new FailedResult(errors);
        }

        private class SuccessfulResult : DataResult<TResult>
        {
            private readonly TResult _result;

            /// <summary>
            /// Initializes a <see cref="SuccessfulResult"/>.
            /// </summary>
            /// <param name="result">
            /// The result of the operation.
            /// </param>
            public SuccessfulResult(TResult result) : base(true)
            {
                _result = result;
            }

            public override TResult GetResult()
            {
                return _result;
            }
        }

        private class FailedResult : DataResult<TResult>
        {
            /// <summary>
            /// Initializes a <see cref="FailedResult"/>.
            /// </summary>
            /// <param name="errors"/>
            /// The errors that caused the result to fail.
            /// </param>
            public FailedResult(DataError[]? errors) : base(false, errors)
            {
            }

            public override TResult GetResult()
            {
                throw new System.InvalidOperationException("Cannot access result of a failed operation");
            }
        }
    }
}
