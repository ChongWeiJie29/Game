using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_standard : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private GameObject crumblyStandardPlatform, num1, num2, num3;
    [SerializeField]
    private EdgeCollider2D platformTop;
    [SerializeField]
    private BoxCollider2D platformBottom;

    public static EdgeCollider2D crumblyStandardTop;
    public static BoxCollider2D crumblyStandardBottom;

    public static float destroyCrumblyTime = 3f;
    private bool destroying = false;

    // Start is called before the first frame update
    void Start()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);

        crumblyStandardTop = platformTop;
        crumblyStandardBottom = platformBottom;
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        collisionCheck();
        movement();
    }
    void movement(){
        if(PlayerControls.joystick.Vertical < PlayerControls.joystickDown && !PlayerControls.jumping && platformTop.IsTouching(playerCollider)){
            Physics2D.IgnoreCollision(platformTop, playerCollider, true);
            PlayerControls.jumping = true;
        }
    }
    void collisionCheck(){
        if(platformBottom.IsTouching(playerCollider) || platformTop.IsTouching(playerCollider)){
            if(!destroying){
                destroying = true;
                StartCoroutine(crumblyDestroy());
            }
        }
    }
    IEnumerator crumblyDestroy(){
        num3.SetActive(true);
        yield return new WaitForSeconds(destroyCrumblyTime/3);
        num3.SetActive(false);
        num2.SetActive(true);
        yield return new WaitForSeconds(destroyCrumblyTime/3);
        num2.SetActive(false);
        num1.SetActive(true);
        yield return new WaitForSeconds(destroyCrumblyTime/3);
        num1.SetActive(false);
        crumblyStandardPlatform.SetActive(false);
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
