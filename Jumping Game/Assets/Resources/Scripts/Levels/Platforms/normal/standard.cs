using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standard : MonoBehaviour
{
    [SerializeField]
    public GameObject platform;
    private Vector2 characterPosition, enemyPosition;
    private float joystickUp, joystickDown;

    // Start is called before the first frame update
    public virtual void Start()
    {
        joystickUp = PlayerControls.joystickUp;
        joystickDown = PlayerControls.joystickDown;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        characterPosition = Level1.selectedCharacterCollider.gameObject.transform.position;
        enemyPosition = Level1.enemyCharacterCollider.gameObject.transform.position;
        platformRules();
    }

    void platformRules()
    {
        Vector2 platformPosition = platform.transform.position;
        Vector2 platformExtents = platform.GetComponent<BoxCollider2D>().bounds.extents;
        Vector2 characterExtents = Level1.selectedCharacterCollider.gameObject.GetComponent<BoxCollider2D>().bounds.extents;
        Vector2 enemyExtents = Level1.enemyCharacterCollider.gameObject.GetComponent<BoxCollider2D>().bounds.extents;

        float platformTop = platformPosition.y + platformExtents.y - 0.015f;
        float characterBottom = characterPosition.y - characterExtents.y + 0.015f;
        float enemyBottom = enemyPosition.y - enemyExtents.y + 0.015f;

        if(platformTop >= characterBottom)
        {
            Physics2D.IgnoreCollision(Level1.selectedCharacterCollider, platform.GetComponent<BoxCollider2D>(), true);
        }
        else{
            if(PlayerControls.joystick.Vertical < joystickDown)
            {
                Physics2D.IgnoreCollision(Level1.selectedCharacterCollider, platform.GetComponent<BoxCollider2D>(), true);
            }
            else
            {
                Physics2D.IgnoreCollision(Level1.selectedCharacterCollider, platform.GetComponent<BoxCollider2D>(), false);
            }
        }

        if(platformTop >= EnemyControls.enemyRB.gameObject.transform.position.y - EnemyControls.enemyRB.gameObject.GetComponent<BoxCollider2D>().bounds.extents.y)
        {
            Physics2D.IgnoreCollision(EnemyControls.enemyRB.gameObject.GetComponent<BoxCollider2D>(), platform.GetComponent<BoxCollider2D>(), true);
        }
        else{
            if(characterBottom < EnemyControls.enemyRB.gameObject.transform.position.y - EnemyControls.enemyRB.gameObject.GetComponent<BoxCollider2D>().bounds.extents.y)
            {
                Physics2D.IgnoreCollision(EnemyControls.enemyRB.gameObject.GetComponent<BoxCollider2D>(), platform.GetComponent<BoxCollider2D>(), true);
            }
            else
            {
                Physics2D.IgnoreCollision(EnemyControls.enemyRB.gameObject.GetComponent<BoxCollider2D>(), platform.GetComponent<BoxCollider2D>(), false);
            }
        }
    }
}
