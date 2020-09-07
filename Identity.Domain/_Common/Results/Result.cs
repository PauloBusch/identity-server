using Identity.Domain._Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Identity.Domain._Common.Results
{
    public class Result<T> where T : class
    {
        [JsonIgnore] public EStatus Status { get; protected set; }
        public int? TotalRows { get; protected set; }
        public T Data { get; protected set; }
        public bool Success
            => Status == EStatus.Success && !_errorMessages.Any();
        public IEnumerable<string> ErrorMessages =>
            _errorMessages.Any() ? _errorMessages.AsReadOnly() : null;

        protected readonly List<string> _errorMessages;

        public Result()
        {
            Status = EStatus.Success;
            _errorMessages = new List<string>();
        }

        public Result(T data, int? total = null) : this()
        {
            Data = data;
            TotalRows = total;
        }

        public Result(EStatus status, string error) : this()
        {
            _errorMessages.Add(error);
            Status = status;
        }

        public Result(EStatus status, IEnumerable<string> errors) : this()
        {
            _errorMessages.AddRange(errors);
            Status = status;
        }
    }

    public class Result : Result<dynamic> {
        public Result() : base() { }

        public Result(dynamic data) : base() { 
            Data = data;
        }

        public Result(EStatus status, string error) : base(status, error) { }

        public Result(EStatus status, IEnumerable<string> errors) : base(status, errors) { }
    }
}
