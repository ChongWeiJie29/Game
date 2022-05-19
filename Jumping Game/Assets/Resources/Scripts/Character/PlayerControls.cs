using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D characterRB;
    public static FloatingJoystick joystick; //-
    public static bool jumping = false; //- //Max Jump is approx 1.8 squares
    public static float joystickDown = -0.7f; //-
    private float joystickUp = 0.5f;

    private BoxCollider2D characterCollider;
    private Animator playerAnim;
    private float playerSpeed = 5;
    private float playerJump = 10.5f;

    /*private EdgeCollider2D standardPlatformTop;
    private EdgeCollider2D thickPlatformTop;
    private EdgeCollider2D crumblyStandardTop;
    private EdgeCollider2D crumblyThickTop;
    private EdgeCollider2D spikyStandardTop;
    private EdgeCollider2D spikyThickTop;

    private BoxCollider2D standardPlatformBottom;
    private BoxCollider2D thickPlatformBottom;
    private BoxCollider2D crumblyStandardBottom;
    private BoxCollider2D crumblyThickBottom;
    private BoxCollider2D spikyStandardBottom;
    private BoxCollider2D spikyThickBottom;*/


    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
        characterRB.gravityScale = 3;
        characterRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        characterRB.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        characterCollider = GetComponent<BoxCollider2D>();
        joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*standardPlatformTop = standard.standardPlatformTop;
        thickPlatformTop = thick.thickPlatformTop;
        crumblyStandardTop = crumbly_standard.crumblyStandardTop;
        crumblyThickTop = crumbly_thick.crumblyThickTop;
        spikyStandardTop = spiky_standard.spikyStandardTop;
        spikyThickTop = spiky_thick.spikyThickTop;

        standardPlatformBottom = standard.standardPlatformBottom;
        thickPlatformBottom = thick.thickPlatformBottom;
        crumblyStandardBottom = crumbly_standard.crumblyStandardBottom;
        crumblyThickBottom = crumbly_thick.crumblyThickBottom;
        spikyStandardBottom = spiky_standard.spikyStandardBottom;
        spikyThickBottom = spiky_thick.spikyThickBottom;*/

        movement();
        cameraBorders();
        StartCoroutine(jumpCheck());
    }

    void movement()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
        {
            characterRB.velocity = new Vector2(joystick.Horizontal*playerSpeed, characterRB.velocity.y);
            if (joystick.Horizontal > 0.2f)
            {
                playerAnim.SetBool("isRunningRight", true);
                playerAnim.SetBool("isRunningLeft", false);
            }
            else if (joystick.Horizontal < -0.2f)
            {
                playerAnim.SetBool("isRunningRight", false);
                playerAnim.SetBool("isRunningLeft", true);
            }
        }
        else
        {
            playerAnim.SetBool("isRunningRight", false);
            playerAnim.SetBool("isRunningLeft", false);
        }

        if (joystick.Vertical > joystickUp && !jumping)
        {
            characterRB.velocity = new Vector2(characterRB.velocity.x, joystick.Vertical*playerJump);
            jumping = true;
        }
    }

    void cameraBorders()
    {
        float xMin;
        float xMax;
        xMin = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x + characterCollider.bounds.size.x/2;
        xMax = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x - characterCollider.bounds.size.x/2;
        characterRB.position = new Vector2(Mathf.Clamp(characterRB.position.x, xMin, xMax), characterRB.position.y);
    }

    IEnumerator jumpCheck(){
        float yPosition1 = GetComponent<Transform>().position.y;
        yield return new WaitForSeconds(0.02f);
        float yPosition2 = GetComponent<Transform>().position.y;
        if(yPosition1 == yPosition2){
            jumping = false;
        }
        else{
            jumping = true;
        }
    }
}

        