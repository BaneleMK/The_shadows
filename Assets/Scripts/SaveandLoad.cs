using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveandLoad
{
    static string path = Application.persistentDataPath + "/Save.Shad";
    static public void savedata(){
        // this is for turning the data into binary for security
        FileStream saver = new FileStream(path, FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();  

        PlayerProgress data = new PlayerProgress(SceneManager.GetActiveScene().name);

        // serializes then writes to stream path
        formatter.Serialize(saver, data);
        saver.Close();
    }

    static public void savenextdata()
    {
        int scenecount = SceneManager.sceneCountInBuildSettings;
        PlayerProgress data = new PlayerProgress(SceneManager.GetActiveScene().name);
        FileStream saver = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        int i;

        for (i = 1; i < scenecount; i++)
        {
            if (System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)) == SceneManager.GetActiveScene().name)
               data = new PlayerProgress(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i + 1)));
        }
        // serializes then writes to stream path
        formatter.Serialize(saver, data);
        saver.Close();
    }

    static public string loadsave(){

        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();  
            FileStream loader = new FileStream(path, FileMode.Open);

            PlayerProgress data = formatter.Deserialize(loader) as PlayerProgress;
            loader.Close();
            return data.savedlevel;

        } else {
            return null;
        }
    }
}
