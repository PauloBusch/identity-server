using Identity.Domain._Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Identity.Domain._Common.Results
{
    public class Result<T> where T : class
    {
        [JsonIgnore] public EStatus Status { get; protected set; }
        [JsonIgnore] public bool Error => !Success;
        public int? TotalRows { get; protected set; }
        public T Data { get; protected set; }
        public bool Success
            => Status == EStatus.Success && !_errorMessages.Any();
        public IDictionary<string, List<string>> ErrorMessages =>
            _errorMessages.Any() ? _errorMessages : null;

        protected readonly IDictionary<string, List<string>> _errorMessages;

        public Result()
        {
            Status = EStatus.Success;
            _errorMessages = new Dictionary<string, List<string>>();
        }

        public Result(T data, int? total = null) : this()
        {
            Data = data;
            TotalRows = total;
        }

        public Result(EStatus status, string field, string error) : this()
        {
            if (!_errorMessages.ContainsKey(field))
                _errorMessages.Add(field, new List<string>());
            _errorMessages[field].Add(error);
            Status = status;
        }

        public Result(EStatus status, string field, IEnumerable<string> errors) : this()
        {
            if (!_errorMessages.ContainsKey(field))
                _errorMessages.Add(field, new List<string>());
            _errorMessages[field].AddRange(errors);
            Status = status;
        }

        public Result(EStatus status, IDictionary<string, List<string>> errorMessages) : this()
        {
            _errorMessages = errorMessages;
            Status = status;
        }

        public void AddError(EStatus status, string field, string error)
        {
            if (!_errorMessages.ContainsKey(field))
                _errorMessages.Add(field, new List<string>());
            _errorMessages[field].Add(error);
            Status = status;
        }
    }

    public class Result : Result<dynamic> {
        public Result() : base() { }

        public Result(dynamic data) : base() { 
            Data = data;
        }

        public Result(EStatus status, string field, string error) : base(status, field, error) { }

        public Result(EStatus status, string field, IEnumerable<string> errors) : base(status, field, errors) { }

        public Result(EStatus status, IDictionary<string, List<string>> errorMessages) : base(status, errorMessages) { }
    }
}
