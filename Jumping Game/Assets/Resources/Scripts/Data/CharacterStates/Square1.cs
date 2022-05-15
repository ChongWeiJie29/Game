using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square1:MonoBehaviour
{
    private static bool unlocked = true;
    public static bool getUnlocked()
    {
        return Square1.unlocked;
    }
    void setUnlocked(bool unlocked)
    {
        Square1.unlocked = unlocked;
    }
}
