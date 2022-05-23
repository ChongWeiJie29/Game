using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMovingBT : StandardPlatform
{
    [SerializeField]
    private GameObject Button;
    public static float defaultShiftRate = StandardMoving.defaultShiftRate;
    private float platformShiftRate = defaultShiftRate;
    private float xLimit = StandardMoving.xLimit;

    public override void Update()
    {
        base.Update();
        buttonPressed();
    }

    void buttonPressed(){
        if(Button.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider)){
            shiftPlatform();
            shiftCharacter();
        }
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
