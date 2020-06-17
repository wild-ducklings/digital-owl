using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    public class DtoResponseResult<T> : DtoResponse
    {
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

        public static DtoResponseResult<T> CreateResponse(T result)
        {
            return new DtoResponseResult<T>(result);
        }

        // TODO make it Failed method
        public static DtoResponseResult<T> CreateResponse(IEnumerable<string> errors)
        {
            return new DtoResponseResult<T>(errors);
        }

        public static DtoResponseResult<T> CreateResponse(string error)
        {
            return new DtoResponseResult<T>(error);
        }
    }
}