using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    [SerializeField]
    private EdgeCollider2D spikeCollider;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        deathCheck();
    }
    void deathCheck(){
        if(playerCollider.IsTouching(spikeCollider)){
            Debug.Log("DIED");
        }
    }
}
