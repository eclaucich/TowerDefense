using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LoadSystem
{
    private static string mainPath = SaveSystem.mainPath;

    public static int LoadBestWave()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        if (Directory.Exists(mainPath))
        {
            Debug.Log("CARGADO DESDE: " + mainPath);
            FileStream bestWaveStream = new FileStream(mainPath + "bestWave.txt", FileMode.Open);
            int bestWave = (int)formatter.Deserialize(bestWaveStream);

            bestWaveStream.Close();

            return bestWave;
        }

        return 0;
    }
}
