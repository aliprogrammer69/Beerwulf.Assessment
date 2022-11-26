using System.Text.Json;

using BeerWulf.Common.Models;

using Microsoft.AspNetCore.Mvc.Formatters;

namespace BeerWulf.UI.Api.Infra {
    public class JsonOutputFormatter : SystemTextJsonOutputFormatter {
        public JsonOutputFormatter(JsonSerializerOptions jsonSerializerOptions) : base(jsonSerializerOptions) {
        }

        public override Task WriteAsync(OutputFormatterWriteContext context) {
            if (context.Object is Result data)
                context.HttpContext.Response.StatusCode = (int)data.Code;

            return base.WriteAsync(context);
        }
    }
}
