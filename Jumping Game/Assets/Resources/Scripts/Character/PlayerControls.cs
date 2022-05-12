using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D characterRB;
    private bool jumping = false;
    private BoxCollider2D characterCollider;
    private BoxCollider2D groundCollider;
    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
        characterCollider = GetComponent<BoxCollider2D>();
        groundCollider = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpAction();
    }

    void jumpAction()
    {
        if(Input.touchCount > 0 && !jumping)
        {
            if (Input.GetTouch(0).position.x > 560)
            {
                characterRB.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
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
}
