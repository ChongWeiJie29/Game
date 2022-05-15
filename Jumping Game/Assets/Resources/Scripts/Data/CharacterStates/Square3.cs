using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square3:MonoBehaviour
{
    private static bool unlocked = true;
    public static bool getUnlocked()
    {
        return Square3.unlocked;
    }
    void setUnlocked(bool unlocked)
    {
        Square3.unlocked = unlocked;
    }
}
