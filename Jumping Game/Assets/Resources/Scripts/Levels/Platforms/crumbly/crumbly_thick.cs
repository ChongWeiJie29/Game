using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbly_thick : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private EdgeCollider2D platformTop; 
    [SerializeField]
    private BoxCollider2D platformBottom;
    [SerializeField]
    private GameObject crumblyThickPlatform, num1, num2, num3;
    private bool destroying = false;

    public static EdgeCollider2D crumblyThickTop;
    public static BoxCollider2D crumblyThickBottom;

    // Start is called before the first frame update
    void Start()
    {
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);

        crumblyThickTop = platformTop;
        crumblyThickBottom = platformBottom;
    }
    // Called once per frame
    void Update()
    {
        playerCollider = Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>();
        collisionCheck();
    }
    void collisionCheck(){
        if(platformBottom.IsTouching(playerCollider) || platformTop.IsTouching(playerCollider)){
            if(!destroying){
                destroying = true;
                StartCoroutine(crumblyDestroy());
            }
            if(platformBottom.IsTouching(playerCollider)){
                PlayerControls.jumping = true;
            }
        }
    }
    IEnumerator crumblyDestroy(){
        num3.SetActive(true);
        yield return new WaitForSeconds(crumbly_standard.destroyCrumblyTime/3);
        num3.SetActive(false);
        num2.SetActive(true);
        yield return new WaitForSeconds(crumbly_standard.destroyCrumblyTime/3);
        num2.SetActive(false);
        num1.SetActive(true);
        yield return new WaitForSeconds(crumbly_standard.destroyCrumblyTime/3);
        num1.SetActive(false);
        crumblyThickPlatform.SetActive(false);
    }
}
