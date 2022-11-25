namespace BeerWulf.Common.Models {
    public class Result {
        public ResultCode Code { get; set; } = ResultCode.Ok;

        public string Message { get; set; }

        public bool Success => Code == ResultCode.Ok;

        public static Result FromNull(ResultCode code, string message = null) {
            return new Result { Code = code, Message = message };
        }

        public Result() { }

        public Result(ResultCode code, string message = null) {
            Code = code;
            Message = message;
        }
    }
}
