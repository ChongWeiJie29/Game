using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class UnlockedCharactersData : MonoBehaviour
{
    private int unlockedCharactersNum;
    private static string filePath = Application.persistentDataPath + "/saveUnlockedCharactersNum.txt";

    public UnlockedCharactersData(int unlockedCharactersNum)
    {
        this.unlockedCharactersNum = unlockedCharactersNum;
    }

    public static void saveUnlockedCharactersNum(UnlockedCharactersData unlockedCharactersNum)
    {
        if (!File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, unlockedCharactersNum);
            dataStream.Close();
        } 
        else
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, unlockedCharactersNum);
            dataStream.Close();
        }
    }

    public static int loadUnlockedCharactersNum()
    {
        if (File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            int unlockedCharactersNum = (int)converter.Deserialize(dataStream);
            dataStream.Close();
            return unlockedCharactersNum;
        } 
        else
        {
            int unlockedCharactersNum = 3;
            return unlockedCharactersNum;
        }
    }

}
