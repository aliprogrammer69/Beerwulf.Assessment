using System.Text.Json;

namespace BeerWulf.Common.Utils {
    public class JsonNetSerializer : ISerializer {
        private readonly JsonSerializerOptions _options;

        public JsonNetSerializer(JsonSerializerOptions options = null) {
            _options = options;
        }

        static JsonNetSerializer() {
            GlobalSetting = SerializerOptions.Global();
        }

        public static JsonSerializerOptions GlobalSetting { get; set; }

        public string Serialize<T>(T model, object options = null) {
            JsonSerializerOptions newtonOption = options as JsonSerializerOptions;
            return JsonSerializer.Serialize(model, newtonOption ?? _options ?? GlobalSetting);
        }

        public T Deserialize<T>(string json, object options = null) {
            return SafeDeserializer<T>(json, options);
        }

        #region Private Mthods
        private T SafeDeserializer<T>(string json, object options = null) {
            try {
                JsonSerializerOptions serializerSettings = options as JsonSerializerOptions;
                return JsonSerializer.Deserialize<T>(json, serializerSettings ?? _options ?? GlobalSetting);
            }
            catch {
                return default;
            }
        }
        #endregion
    }
}
