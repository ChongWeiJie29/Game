using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square:MonoBehaviour
{
    private static bool unlocked = true;
    public static bool getUnlocked()
    {
        return Square.unlocked;
    }
    void setUnlocked(bool unlocked)
    {
        Square.unlocked = unlocked;
    }
}
