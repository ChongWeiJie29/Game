using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Character1
{
    private static bool unlocked;
    private static string filePath = Application.persistentDataPath + "/saveCharacter1State.txt";
    public static bool getUnlocked()
    {
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bool saveCharacterState = (bool) bf.Deserialize(fs);
            fs.Close();
            return saveCharacterState;
        } 
        else
        {
            bool saveCharacterState = true;
            return saveCharacterState;
        }
    }
    public static void setUnlocked(bool unlocked)
    {
        Character1.unlocked = unlocked;
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character1.unlocked);
            fs.Close();
        } 
        else
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character1.unlocked);
            fs.Close();
        }
    }
}
