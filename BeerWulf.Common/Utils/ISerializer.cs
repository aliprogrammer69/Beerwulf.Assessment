namespace BeerWulf.Common.Utils {
    public interface ISerializer {
        string Serialize<T>(T model, object options = null);
        T Deserialize<T>(string json, object options = null);
    }
}
