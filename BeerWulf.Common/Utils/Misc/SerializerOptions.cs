using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace BeerWulf.Common.Utils {
    public static class SerializerOptions {
        public static readonly Func<JsonSerializerOptions> Global = () => {
            var result = new JsonSerializerOptions() {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)

            };
            return result;
        };

        public static readonly Func<JsonSerializerOptions> CaseSencetive = () => {
            var result = new JsonSerializerOptions() {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            return result;
        };
    }
}
