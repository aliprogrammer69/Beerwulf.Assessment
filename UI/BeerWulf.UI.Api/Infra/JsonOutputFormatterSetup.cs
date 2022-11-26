using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BeerWulf.UI.Api.Infra {
    public class JsonOutputFormatterSetup : IConfigureOptions<MvcOptions> {
        private readonly JsonOptions _options;
        public JsonOutputFormatterSetup(IOptions<JsonOptions> options) {
            _options = options.Value;
        }

        public void Configure(MvcOptions options) {
            options.OutputFormatters.Insert(0, new JsonOutputFormatter(_options.JsonSerializerOptions));
        }
    }
}
