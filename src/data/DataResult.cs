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
    public sealed class DataResult<TResult> : DataResult where TResult : new()
    {
        private readonly TResult _result;

        /// <summary>
        /// Initializes a <see cref="DataResult{TResult}"/>.
        /// </summary>
        /// <param name="success">
        /// Whether the data operation was successful or not.
        /// </param>
        /// <param name="result">
        /// The result of the operation.
        /// </param>
        /// <param name="errors">
        /// The errors that occurred to make the operation fail.
        /// </param>
        private DataResult(bool success, TResult result, DataError[]? errors = null) : base(success, errors)
        {
            _result = result;
        }

        /// <summary>
        /// Gets the result of the data operation.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"/>
        /// Thrown when trying to access the result of a failed operation.
        /// </exception>
        public TResult GetResult()
        {
            if (!Succeeded)
            {
                throw new System.InvalidOperationException("Cannot access result of failed operation");
            }
            return _result;
        }

        /// <summary>
        /// Creates a new <see cref="DataResult{TResult}"/> for a successful operation.
        /// </summary>
        /// <param name="result">
        /// The result of the operation.
        /// </param>
        internal static new DataResult<TResult> Success(TResult result)
        {
            return new DataResult<TResult>(true, result);
        }

        /// <summary>
        /// Creates a new <see cref="DataResult{TResult}"/> for a failed operation.
        /// </summary>
        /// <param name="errors"/>
        /// The <see cref="DataError"/>s that occured.
        /// </param>
        internal static new DataResult<TResult> Failure(params DataError[] errors)
        {
            return new DataResult<TResult>(false, new TResult(), errors);
        }
    }
}
