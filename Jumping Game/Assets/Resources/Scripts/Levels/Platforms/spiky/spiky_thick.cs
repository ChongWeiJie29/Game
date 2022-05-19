using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiky_thick : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private EdgeCollider2D platformTop; 
    [SerializeField]
    private BoxCollider2D platformBottom;

    public static EdgeCollider2D spikyThickTop;
    public static BoxCollider2D spikyThickBottom;

    // Start is called before the first frame update
    void Start()
    {
        spikyThickTop = platformTop;
        spikyThickBottom = platformBottom;
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        collisionCheck();
    }
    void collisionCheck(){
        if(platformBottom.IsTouching(playerCollider)){
            PlayerControls.jumping = true;
        }
    }
}
