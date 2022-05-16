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
        characterCollider = GetComponent<BoxCollider2D>();
        groundCollider = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpAction();
        joystickControls();
        cameraBorders();
    }

    void jumpAction()
    {
        if(Input.touchCount == 1 && !jumping)
        {
            if (Input.GetTouch(0).position.x > 560)
            {
                characterRB.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                jumping = true;
            }
        } 
        else if (Input.touchCount == 2 && !jumping)
        {
            if (Input.GetTouch(0).position.x > 560 || Input.GetTouch(1).position.x > 560)
            {
                characterRB.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                jumping = true;
            }
        }
        checkOnGround();
    }

    void checkOnGround()
    {
        if (characterCollider.IsTouching(groundCollider))
        {
            if(Input.touchCount != 0)
            {
                jumping = true;
                return;
            }
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
            float direction = pointB.x - pointA.x;
            characterRB.velocity = new Vector2(direction*3, characterRB.velocity.y);
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
