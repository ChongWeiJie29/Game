using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Collider2D contactCollider;
    private Vector3 platformPosition;
    private Vector3 platformExtents;
    private Vector3 characterExtents;
    private Vector3 characterPosition;

    private Rigidbody2D characterRB;
    public static FloatingJoystick joystick;
    public static bool jumping = false; //Max Jump is approx 1.8 squares
    public static float joystickDown = -0.7f;
    public static float joystickUp = 0.5f;

    private BoxCollider2D characterCollider;
    private Animator playerAnim;
    private float playerSpeed = 5;
    private float playerJump = 10.5f;


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
        //StartCoroutine(jumpCheck());
        characterPosition = characterCollider.gameObject.transform.position;

        //Debug.Log("current = " + contactCollider.gameObject.name);
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

        if(joystick.Vertical > joystickUp && !jumping){
            //if(characterCollider.IsTouching(contactCollider.GetComponent<EdgeCollider2D>())){
                characterRB.velocity = new Vector2(characterRB.velocity.x, joystick.Vertical*playerJump);
                jumping = true;
            //}
        }
        /*if(joystick.Vertical < joystickDown && !jumping){
            if(contactCollider.gameObject.name.Substring(0, 8) == "Standard"){
                Physics2D.IgnoreCollision(contactCollider.gameObject.GetComponent<EdgeCollider2D>(), characterCollider, true);
                jumping = true;
            }
        }*/
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

    void OnCollisionEnter2D(Collision2D other){
        if(other.contacts.Length > 0)
        {
            ContactPoint2D contact = other.contacts[0];
            if(Vector2.Dot(contact.normal, Vector2.up) > 0.5)
            {
                jumping = false;
                Debug.Log("yay");
            }
        }

        /*platformPosition = other.gameObject.transform.position;
        platformExtents = other.collider.bounds.extents;

        float platformTop = platformPosition.y + platformExtents.y - 0.02f;
        float platformRight = platformPosition.x + platformExtents.x - 0.02f;
        float platformLeft = platformPosition.x - platformExtents.x + 0.02f;

        characterExtents = characterCollider.bounds.extents;
        
        float characterBottom = characterPosition.y - characterExtents.y + 0.01f;
        float characterRight = characterPosition.x + characterExtents.x - 0.01f;
        float characterLeft = characterPosition.x - characterExtents.x + 0.01f;

        if((platformTop) <= (characterBottom)){
            if(platformLeft > characterRight || platformRight > characterLeft){
                contactCollider = other.collider;
            }
        }*/
    }
}
