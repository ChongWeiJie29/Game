using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static Rigidbody2D characterRB;
    public static FloatingJoystick joystick;
    public static bool jumping = false; // Max Jump is approx 1.8 squares
    public static float joystickDown = -0.7f;
    public static float joystickUp = 0.5f;

    private BoxCollider2D characterCollider;
    private Animator playerAnim;

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
        movement();
        cameraBorders();
    }
    void movement()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
        {
            characterRB.velocity = new Vector2(joystick.Horizontal*4, characterRB.velocity.y);
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
            characterRB.velocity = new Vector2(characterRB.velocity.x*2, joystick.Vertical*10.5f);
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
}
