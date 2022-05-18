using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_thick : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private BoxCollider2D platformCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        if(platformCollider.IsTouching(playerCollider)){
            PlayerControls.jumping = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name==playerCollider.gameObject.name){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name==playerCollider.gameObject.name){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
    }
}
