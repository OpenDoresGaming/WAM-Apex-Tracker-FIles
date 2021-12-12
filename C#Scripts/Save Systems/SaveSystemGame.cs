using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemGame
{
 public static void SaveGame (GameScript game)
    {
        //Saves from BlorpData
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Games.saves";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(game);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static GameData LoadGame ()
    {
        //Loads to BlorpData
        string path = Application.persistentDataPath + "/Games.saves";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save Not Found in " + path);
            return null;
        }
    }
}