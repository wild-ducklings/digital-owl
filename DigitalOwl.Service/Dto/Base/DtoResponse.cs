using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    public class ResponseDto
    {
        public IEnumerable<string> Errors { get; private set; }
        public bool Succeeded { get; private set; }

        protected ResponseDto(IEnumerable<string> errors)
        {
            Errors = errors;
            Succeeded = false;
        }

        protected ResponseDto(string error)
        {
            Errors = new List<string> {error};
            Succeeded = false;
        }

        protected ResponseDto(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public static ResponseDto Failed(IEnumerable<string> errors)
        {
            return new ResponseDto(errors);
        }

        public static ResponseDto Failed(string error)
        {
            return new ResponseDto(error);
        }
        
        public static ResponseDto Success()
        {
            return new ResponseDto(true);
        }
    }
}