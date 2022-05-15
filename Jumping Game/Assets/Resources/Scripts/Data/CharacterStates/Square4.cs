using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square4:MonoBehaviour
{
    private static bool unlocked = true;
    public static bool getUnlocked()
    {
        return Square4.unlocked;
    }
    void setUnlocked(bool unlocked)
    {
        Square4.unlocked = unlocked;
    }
}
