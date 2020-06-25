using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    /// <summary>
    /// Data transfer object.
    /// </summary>
    public class DtoResponse
    {
        /// <summary>
        /// Errors that may occur during requests.
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }
        /// <summary>
        /// Information of whether the task was completed successfully. 
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// ctor (fail for IEnumerable).
        /// </summary>
        /// <param name="errors"></param>
        protected DtoResponse(IEnumerable<string> errors)
        {
            Errors = errors;
            Succeeded = false;
        }

        /// <summary>
        /// ctor (fail).
        /// </summary>
        /// <param name="error"></param>
        protected DtoResponse(string error)
        {
            Errors = new List<string> {error};
            Succeeded = false;
        }

        /// <summary>
        /// Ctor (success).
        /// </summary>
        /// <param name="succeeded"></param>
        protected DtoResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        /// <summary>
        /// Dto response for failed action (IEnumerable).
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static DtoResponse Failed(IEnumerable<string> errors)
        {
            return new DtoResponse(errors);
        }

        /// <summary>
        /// Dto response for failed action.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static DtoResponse Failed(string error)
        {
            return new DtoResponse(error);
        }
        
        /// <summary>
        /// Dto response for succeeded action.
        /// </summary>
        /// <returns></returns>
        public static DtoResponse Success()
        {
            return new DtoResponse(true);
        }
    }
}