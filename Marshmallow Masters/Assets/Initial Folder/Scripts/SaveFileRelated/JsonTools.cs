using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class JsonTools
{
    /// <summary>
    /// Serializes an object then saves it to the intended path.
    /// </summary>
    /// <param name="objectToSerialize">The object to serialize and then save.</param>
    /// <param name="path">The path to save the file to.</param>
    /// 

    //Saving
    public static void SaveSerializedObject(object objectToSerialize, string path, string fileName)
    {

        string json = JsonUtility.ToJson(obj: objectToSerialize, prettyPrint: true);
        if (string.IsNullOrEmpty(value: json))
        {
            Debug.LogError(message: "Json serialization failed, cannot write the file.");
        }

        if (!System.IO.Directory.Exists(path: path))
        {
            System.IO.Directory.CreateDirectory(path: path);
        }

        System.IO.File.WriteAllText(path: string.Format(format: "{0}" + "/" + "{1}", arg0: path, arg1: fileName), contents: json);
    }
    //Loading
    public static T DeserializeObject<T>(string path)
    {
        if (!System.IO.File.Exists(path: path))
        {
            Debug.LogError(message: "Json File at path: " + path + " does not exist.");
        }

        return JsonUtility.FromJson<T>(json: System.IO.File.ReadAllText(path: path));
    }
}

