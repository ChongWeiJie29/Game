using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D characterRB;
    private bool jumping = false;
    private BoxCollider2D characterCollider;
    private BoxCollider2D groundCollider;
    private Vector2 pointA;
    private Vector2 pointB;
    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
        characterRB.gravityScale = 2;
        characterRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        characterCollider = GetComponent<BoxCollider2D>();
        groundCollider = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        joystickControls();
        cameraBorders();
    }

    void checkOnGround()
    {
        if (characterCollider.IsTouching(groundCollider))
        {
            jumping = false;
        }
    }

    void joystickControls()
    {
        bool isHolding = false;
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        if (Input.GetMouseButton(0))
        {
            isHolding = true;
            pointB = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        else{
            isHolding = false;
        }
        if (isHolding)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            characterRB.velocity = new Vector2(direction.x*700*Time.deltaTime, characterRB.velocity.y);
            if(direction.y >= 0.5 && !jumping)
            {
                characterRB.AddForce(Vector2.up * 200 *Time.deltaTime, ForceMode2D.Impulse);
                jumping = true;
            }
            checkOnGround();
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
