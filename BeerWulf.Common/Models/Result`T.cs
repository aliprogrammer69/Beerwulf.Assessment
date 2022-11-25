namespace BeerWulf.Common.Models {
    public class Result<T> : Result {
        public Result() : base() { }

        public Result(ResultCode code, string message = null) : base(code, message) { }

        public T Data { get; set; }
    }
}
