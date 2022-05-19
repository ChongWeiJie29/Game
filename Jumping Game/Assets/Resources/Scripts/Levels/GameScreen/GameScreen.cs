using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject gameScreen;
    private float panRate = -0.001f;
    public static Vector3 panVector;
    public static bool panEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        panVector = new Vector3(0f, panRate, 0f);
        StartCoroutine(waitToPan());
    }
    // Update is called once per frame
    void Update()
    {
        //panDown();
    }
    void panDown(){
        if(panEnabled){
            gameScreen.transform.position += panVector;
        }
    }
    IEnumerator waitToPan(){
        yield return new WaitForSeconds(3);
        panEnabled = true;
    }
}
