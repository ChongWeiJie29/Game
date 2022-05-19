using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private EdgeCollider2D spikeCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other == playerCollider){
            Debug.Log("DIED");
        }
    }
    void OnTriggerExit2D(Collider2D other){

    }
}
