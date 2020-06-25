using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    /// <summary>
    /// Response result dto.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DtoResponseResult<T> : DtoResponse
    {
        /// <summary>
        /// Result of an action.
        /// </summary>
        public T Result { get; set; }
        
        private DtoResponseResult(T result) : base(true)
        {
            Result = result;
        }

        private DtoResponseResult(IEnumerable<string> errors) : base(errors)
        {
        }

        private DtoResponseResult(string error) : base(error)
        {
        }

        private DtoResponseResult(bool succeeded) : base(succeeded)
        {
        }

        /// <summary>
        /// Create dto response.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static DtoResponseResult<T> CreateResponse(T result)
        {
            return new DtoResponseResult<T>(result);
        }

        /// <summary>
        /// Failed dto response (for IEnumerable).
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static DtoResponseResult<T> FailedResponse(IEnumerable<string> errors)
        {
            return new DtoResponseResult<T>(errors);
        }

        /// <summary>
        /// Failed dto response.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DtoResponseResult<T> FailedResponse(string error)
        {
            return new DtoResponseResult<T>(error);
        }
    }
}