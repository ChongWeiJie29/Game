using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiky_thick : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private BoxCollider2D platformCollider, platformTrigger;

    // Start is called before the first frame update
    void Start()
    {
              
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        collisionCheck();
    }
    void collisionCheck(){
        if(platformCollider.IsTouching(playerCollider)){
            if(platformTrigger.IsTouching(playerCollider)){
                PlayerControls.jumping = true;
            }
            else{
                PlayerControls.jumping = false;
            }
        }
    }
}
