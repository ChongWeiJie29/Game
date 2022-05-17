using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thick : MonoBehaviour
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
    void Update()
    {
        playerCollider = GameObject.Find("scientist v2_0(Clone)").GetComponent<BoxCollider2D>();
        Debug.Log(playerCollider);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name=="scientist v2_0(Clone)"){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.name=="scientist v2_0(Clone)"){
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
        }
    }
}
