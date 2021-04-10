using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*

Handles saving to the system different game properties and values

*/

public static class SaveSystem
{
    public static string mainPath = Application.persistentDataPath + "/TowerDefense/";

    public static void SaveBestWave(int currentWave)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        Directory.CreateDirectory(mainPath);                                                               

        FileStream stream = new FileStream(mainPath + "bestWave.txt", FileMode.Create);                    

        int bestWave = currentWave;                                       

        formatter.Serialize(stream, bestWave);                                                       
        stream.Close();

        Debug.Log("GUARDADO EN: " + mainPath);
    }
}
