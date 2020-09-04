using Newtonsoft.Json;

namespace Identity.Domain.Utils.Responses
{
    public class Response<T> where T : class
    {
        [JsonIgnore] public EStatus Status { get; protected set; }
        public bool Success => Status == EStatus.Success;
        public string Message { get; private set; }
        public int? TotalRows { get; private set; }
        public T Data { get; private set; }

        public Response(EStatus status, string message)
        {
            Message = message;
            Status = status;
            TotalRows = 0;
        }

        public Response(T data, int? total = null) { 
            Data = data;  
            TotalRows = total;
        }
    }

    public class Response : Response<dynamic>
    {
        public Response() : base(EStatus.Success, null) { }

        public Response(EStatus status, string message) : base(status, message) { }
    }
}
