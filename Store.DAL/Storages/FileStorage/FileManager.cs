using Newtonsoft.Json;

namespace Store.DAL.Storages.FileStorage;

public class FileManager
{
    public static async Task<List<T>> ReadAllFromFileAsync<T>(string fileName)
    {
        var path = "D:\\TryHARD\\ООП\\Store\\Store.DAL\\Storages\\FileStorage" + fileName;
        var json = await File.ReadAllTextAsync(path);

        if (string.IsNullOrEmpty(json))
        {
            return new List<T>();
        }

        var deserializedData = JsonConvert.DeserializeObject<List<T>>(json);
        return deserializedData ?? new List<T>();
    }

    public static async Task WriteToFileAsync<T>(string fileName, T data)
    {
        var collection = await ReadAllFromFileAsync<T>(fileName);
        collection.Add(data);

        var path = "D:\\TryHARD\\ООП\\Store\\Store.DAL\\Storages\\FileStorage" + fileName;
        var json = JsonConvert.SerializeObject(collection, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
    }
}