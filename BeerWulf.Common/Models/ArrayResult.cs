namespace BeerWulf.Common.Models {
    public class ArrayResult<T> : Result {
        public ArrayResult() : base() { }

        public ArrayResult(ResultCode code, string message = null) : base(code, message) { }

        public IEnumerable<T> Data { get; set; }
    }
}
