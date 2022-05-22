using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_moving_standard : crumbly_standard
{
    private static float defaultShiftRate = moving_standard.defaultShiftRate;
    private float platformShiftRate = defaultShiftRate;
    private float xLimit = moving_standard.xLimit;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        shiftCharacter();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
        if(platform.transform.position.x >= xLimit || platform.transform.position.x <= -xLimit)
        {
            platformShiftRate *= -1;
        }
    }

    void shiftCharacter()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider))
        {
            Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
        }
    }
}
