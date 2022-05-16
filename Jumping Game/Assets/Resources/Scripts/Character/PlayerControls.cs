using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D characterRB;
    private FloatingJoystick joystick;
    private bool jumping = false;
    private BoxCollider2D characterCollider;
    private BoxCollider2D groundCollider;
    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
        characterRB.gravityScale = 2;
        characterRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        characterCollider = GetComponent<BoxCollider2D>();
        groundCollider = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
        joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();
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
            characterRB.velocity = new Vector2(joystick.Horizontal*3, characterRB.velocity.y);
        }
        if (joystick.Vertical > 0.5f && !jumping)
        {
            characterRB.velocity = new Vector2(characterRB.velocity.x, joystick.Vertical*9);
            jumping = true;
        }
    if (characterCollider.IsTouching(groundCollider))
        {
            jumping = false;
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
