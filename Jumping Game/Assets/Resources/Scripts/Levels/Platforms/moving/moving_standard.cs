using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_standard : standard
{
    public static float shiftRate = 0.004f;
    public static float xLimit = 1.04f;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        shiftCharacter();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(shiftRate, 0f, 0f);
        if(platform.transform.position.x >= xLimit || platform.transform.position.x <= -xLimit)
        {
            shiftRate *= -1;
        }
    }

    void shiftCharacter()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider))
        {
            Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(shiftRate, 0f, 0f);
        }
    }
}
