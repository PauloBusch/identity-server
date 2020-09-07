using Identity.Domain._Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Domain._Common.Results
{
    public class Result<T> where T : class
    {
        public T Data { get; protected set; }
        public int? TotalRows { get; protected set; }
        public bool Success
            => _status == EStatus.Success;
        public IEnumerable<string> ErrorMessages
            => _errorMessages.Any() ? ErrorMessages : null;

        protected EStatus _status;
        protected readonly List<string> _errorMessages;

        protected Result()
        {
            _status = EStatus.Success;
            _errorMessages = new List<string>();
        }

        public Result(T data, int total) : this()
        {
            Data = data;
            TotalRows = total;
        }

        public Result(EStatus status, string error) : this()
        {
            _errorMessages.Add(error);
            _status = status;
        }

        public Result(EStatus status, IEnumerable<string> errors) : this()
        {
            _errorMessages.AddRange(errors);
            _status = status;
        }

        public int StatusCode() => (int)_status;
    }

    public class Result : Result<dynamic> {
        public Result(int total) : base()
        {
            TotalRows = total;
        }
    }
}
