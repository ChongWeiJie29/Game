using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standard : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private BoxCollider2D platformCollider, platformTrigger;
    private float joystickDown = PlayerControls.joystickDown;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
        collisionCheck();
        movement();
    }
    void collisionCheck(){
        if(platformCollider.IsTouching(playerCollider)){
            PlayerControls.jumping = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name==playerCollider.gameObject.name){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            Debug.Log("phasing");
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name==playerCollider.gameObject.name){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
            Debug.Log("not phasing");
        }
    }
    void movement(){
        if (PlayerControls.joystick.Vertical < joystickDown && !PlayerControls.jumping && platformCollider.IsTouching(playerCollider)){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            PlayerControls.jumping = true;
        }
    }
}
