using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square2:MonoBehaviour
{
    private static bool unlocked = true;
    public static bool getUnlocked()
    {
        return Square2.unlocked;
    }
    void setUnlocked(bool unlocked)
    {
        Square2.unlocked = unlocked;
    }
}
