using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Código da criação/atualização do ficheiro de save
    public static void SaveLevel(canvasmanagerL2 canvasmanagerL2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.sve";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(canvasmanagerL2);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData LoadLevel()
    {
        //Código do load do ficheiro de save
        string path = Application.persistentDataPath + "/level.sve";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteSave()
    {
        //Código para apagar o ficheiro de save
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.sve";
        File.Delete(path);
    }
}
