using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_standard : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private GameObject crumblyStandardPlatform, num1, num2, num3;
    [SerializeField]
    private BoxCollider2D platformCollider, platformTrigger;
    public static float destroyCrumblyTime = 2.5f;
    private bool destroying = false;

    // Start is called before the first frame update
    void Start()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
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
        if (PlayerControls.joystick.Vertical < -0.7f && !PlayerControls.jumping && platformCollider.IsTouching(playerCollider)){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
            PlayerControls.jumping = true;
        }
    }
}
