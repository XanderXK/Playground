using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    private const string SceneKey = "currentSceneName";

    public static void Save(string fileName)
    {
        var dict = new Dictionary<string, object>();
        var saveableEntities = FindObjectsByType<SaveableEntity>(FindObjectsSortMode.None);
        dict[SceneKey] = SceneManager.GetActiveScene().name;

        foreach (var item in saveableEntities)
        {
            dict[item.GetId()] = item.CaptureState();
        }

        SaveFile(fileName, dict);
    }

    public static void Load(string fileName)
    {
        var dict = LoadFile(fileName);
        var saveableEntities = FindObjectsByType<SaveableEntity>(FindObjectsSortMode.None);
        foreach (var item in saveableEntities)
        {
            var id = item.GetId();
            if (dict.TryGetValue(id, out var value))
            {
                item.RestoreState(value);
            }
        }

        if (dict.TryGetValue(SceneKey, out var sceneValue))
        {
            var sceneName = (string)sceneValue;
            SceneManager.LoadScene(sceneName);
        }
    }

    public static string[] GetAllFiles()
    {
        var dirPath = GetSaveDirPath();
        return Directory.GetFiles(dirPath).OrderBy(file => File.GetLastWriteTime(file)).Reverse()
            .Select(file => Path.GetFileName(file)).ToArray();
    }

    private static Dictionary<string, object> LoadFile(string saveFile)
    {
        var path = Path.Combine(GetSaveDirPath(), saveFile);
        if (!File.Exists(path))
        {
            return new Dictionary<string, object>();
        }

        using var streamReader = new StreamReader(path);
        var jsonSerializer = GetSerializer();

        return (Dictionary<string, object>)jsonSerializer.Deserialize(streamReader, typeof(Dictionary<string, object>));
    }

    private static void SaveFile(string saveFile, object state)
    {
        var path = Path.Combine(GetSaveDirPath(), saveFile);
        using var streamWriter = new StreamWriter(path);
        var jsonSerializer = GetSerializer();
        jsonSerializer.Serialize(streamWriter, state);
    }

    public static void DeleteFile(string saveFile)
    {
        var filePath = Path.Combine(GetSaveDirPath(), saveFile);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    private static string GetSaveDirPath()
    {
        var path = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
        var dir = Path.Combine(path, "..", "Saves");
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        return dir;
    }

    private static JsonSerializer GetSerializer()
    {
        return new JsonSerializer
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };
    }
}