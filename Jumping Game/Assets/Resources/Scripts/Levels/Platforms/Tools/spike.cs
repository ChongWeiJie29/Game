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
        deathCheck();
    }
    void deathCheck(){
        if(spikeCollider.IsTouching(Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>())){
            Debug.Log("DIED");
        }
    }
}
