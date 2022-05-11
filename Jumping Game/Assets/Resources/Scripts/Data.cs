using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Data
{
    public float soundSliderValue = 0;
    public float musicSliderValue = 0;
    public static string filePath;
    public Data(float soundSliderValue, float musicSliderValue)
    {
        this.soundSliderValue = soundSliderValue;
        this.musicSliderValue = musicSliderValue;
    }

    public static void saveSettingsFunction(Data saveData)
    {
        filePath = Application.persistentDataPath + "/save.txt";
        if (!File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, saveData);
            dataStream.Close();
        } 
        else
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, saveData);
            dataStream.Close();
        }
    }

    public static Data LoadGameFunction()
    {
        filePath = Application.persistentDataPath + "/save.txt";
        if(File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            Data saveData = (Data)converter.Deserialize(dataStream);

            dataStream.Close();
            return saveData; 
        }
        else
        {
            Data saveData = new Data(0, 0);
            return saveData;
        }
    }
}
