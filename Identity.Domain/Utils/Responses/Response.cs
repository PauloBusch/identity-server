using Identity.Domain.Utils.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Identity.Domain.Utils.Responses
{
    public class Response<T> where T : class
    {
        [JsonIgnore] public EStatus Status { get; protected set; }
        public bool Success => Status == EStatus.Success;
        public IReadOnlyCollection<string> ErrorMessages 
            => _errors.Count > 0 ? _errors.AsReadOnly() : null;
        public int? TotalRows { get; private set; }
        public T Data { get; private set; }

        private List<string> _errors;

        protected Response()
        {
            Status = EStatus.Success;
            _errors = new List<string>();
        }

        public Response(T data, int? total = 0) : this() { 
            TotalRows = total;
            Data = data;
        }

        public Response(EStatus status, string error) : this()
        {
            _errors.Add(error);
            Status = status;
        }

        public Response(EStatus status, IEnumerable<string> errors) : this()
        {
            _errors.AddRange(errors);
            Status = status;
        }
    }

    public class Response : Response<dynamic>
    {
        public Response() : base() { }

        public Response(EStatus status, string error) : base(status, error) { }
        public Response(EStatus status, IEnumerable<string> errors) : base(status, errors) { }
    }
}
