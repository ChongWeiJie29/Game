using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickPlatform : MonoBehaviour
{
    [SerializeField]
    public GameObject platform;
    public float xOriginal, yOriginal;

    public Vector2 platformPosition, platformExtents;
    public float platformTop, platformLeft, platformRight;

    public Vector2 characterPosition, characterExtents;
    public float characterBottom, characterLeft, characterRight;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        xOriginal = platform.transform.position.x;
        yOriginal = platform.transform.position.y;
    }
    // Called once per frame
    public virtual void Update()
    {
        platformPosition = platform.transform.position;
        platformExtents = platform.GetComponent<BoxCollider2D>().bounds.extents;
        platformTop = platformPosition.y + platformExtents.y - 0.015f;
        platformLeft = platformPosition.x - platformExtents.x + 0.015f;
        platformRight = platformPosition.x + platformExtents.x - 0.015f;

        characterPosition = Level1.selectedCharacterCollider.gameObject.GetComponent<Transform>().position;
        characterExtents = Level1.selectedCharacterCollider.gameObject.GetComponent<BoxCollider2D>().bounds.extents;
        characterBottom = characterPosition.y - characterExtents.y + 0.015f;
        characterLeft = characterPosition.x - characterExtents.x + 0.015f;
        characterRight = characterPosition.x + characterExtents.x - 0.015f;

        checkCollision();
    }

    void checkCollision()
    {
        float charDeflect = 0.05f;

        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterLeft >= platformRight)
        {
            Level1.selectedCharacterCollider.gameObject.GetComponent<Transform>().position += new Vector3(charDeflect, 0f, 0f);
        }
        else if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterRight <= platformLeft)
        {
            Level1.selectedCharacterCollider.gameObject.GetComponent<Transform>().position -= new Vector3(charDeflect, 0f, 0f);
        }
    }
}
