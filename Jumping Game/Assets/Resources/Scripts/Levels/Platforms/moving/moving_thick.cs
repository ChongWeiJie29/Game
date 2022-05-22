using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_thick : thick
{
    private float shiftRate = -moving_standard.defaultShiftRate;
    private float xLimit = moving_standard.xLimit;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        checkTouchTop();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(shiftRate, 0f, 0f);
        if(platform.transform.position.x >= xLimit || platform.transform.position.x <= -xLimit)
        {
            shiftRate *= -1;
        }
    }

    void checkTouchTop()
    {
        Vector2 platformPosition = platform.transform.position;
        Vector2 platformExtents = platform.GetComponent<BoxCollider2D>().bounds.extents;
        Vector2 characterPosition = Level1.selectedCharacterCollider.gameObject.GetComponent<Transform>().position;
        Vector2 characterExtents = Level1.selectedCharacterCollider.gameObject.GetComponent<BoxCollider2D>().bounds.extents;

        float platformTop = platformPosition.y + platformExtents.y - 0.015f;
        float characterBottom = characterPosition.y - characterExtents.y + 0.015f;
        
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterBottom >= platformTop)
        {
            shiftCharacter();
        }
    }

    void shiftCharacter()
    {
        Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(shiftRate, 0f, 0f);
    }

}
