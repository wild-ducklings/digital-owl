using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    public class ResponseResultDto<T> : ResponseDto
    {
        public T Result { get; set; }

        private ResponseResultDto(T result) : base(true)
        {
            Result = result;
        }

        private ResponseResultDto(IEnumerable<string> errors) : base(errors)
        {
        }

        private ResponseResultDto(string error) : base(error)
        {
        }

        private ResponseResultDto(bool succeeded) : base(succeeded)
        {
        }

        public static ResponseResultDto<T> CreateResponse(T result)
        {
            return new ResponseResultDto<T>(result);
        }

        public static ResponseResultDto<T> CreateResponse(IEnumerable<string> errors)
        {
            return new ResponseResultDto<T>(errors);
        }

        public static ResponseResultDto<T> CreateResponse(string error)
        {
            return new ResponseResultDto<T>(error);
        }
    }
}