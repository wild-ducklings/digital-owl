using System.Collections.Generic;

namespace DigitalOwl.Service.Dto.Base
{
    public class DtoResponse
    {
        public IEnumerable<string> Errors { get; private set; }
        public bool Succeeded { get; private set; }

        protected DtoResponse(IEnumerable<string> errors)
        {
            Errors = errors;
            Succeeded = false;
        }

        protected DtoResponse(string error)
        {
            Errors = new List<string> {error};
            Succeeded = false;
        }

        protected DtoResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public static DtoResponse Failed(IEnumerable<string> errors)
        {
            return new DtoResponse(errors);
        }

        public static DtoResponse Failed(string error)
        {
            return new DtoResponse(error);
        }
        
        public static DtoResponse Success()
        {
            return new DtoResponse(true);
        }
    }
}