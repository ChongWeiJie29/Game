using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standard : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private EdgeCollider2D platformTop;
    [SerializeField]
    private BoxCollider2D platformBottom;
    
    public static EdgeCollider2D standardPlatformTop;
    public static BoxCollider2D standardPlatformBottom;

    // Start is called before the first frame update
    void Start()
    {
        standardPlatformTop = platformTop;
        standardPlatformBottom = platformBottom;
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        movement();
    }
    void movement(){
        if(PlayerControls.joystick.Vertical < PlayerControls.joystickDown && !PlayerControls.jumping && platformTop.IsTouching(playerCollider)){
            Physics2D.IgnoreCollision(platformTop, playerCollider, true);
            PlayerControls.jumping = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other == playerCollider){
            Physics2D.IgnoreCollision(platformTop, playerCollider, true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other == playerCollider){
            Physics2D.IgnoreCollision(platformTop, playerCollider, false);
        }
    }
}
