using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject gameScreen;
    private float panRate = 0.021f;
    public static Vector3 panVector;
    public static bool panEnabled = false;
    private float joystickDown = PlayerControls.joystickDown;
    private float joystickUp = PlayerControls.joystickUp;

    // Start is called before the first frame update
    void Start()
    {
        panVector = new Vector3(0f, panRate, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        camControl();
    }
    void camControl(){
        if(PlayerControls.joystick.Vertical > joystickUp && PlayerControls.jumping){
            gameScreen.transform.position -= panVector;
        }
        if(PlayerControls.joystick.Vertical < joystickDown && PlayerControls.jumping){
            gameScreen.transform.position += panVector;
        }
    }
}
