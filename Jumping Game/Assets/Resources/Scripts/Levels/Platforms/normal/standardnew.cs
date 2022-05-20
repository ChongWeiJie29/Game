using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standardnew : MonoBehaviour
{
    private float joystickUp, joystickDown;

    // Start is called before the first frame update
    void Start()
    {
        joystickUp = PlayerControls.joystickUp;
        joystickDown = PlayerControls.joystickDown;
    }

    // Update is called once per frame
    void Update()
    {
        joystickPosition();
    }

    void joystickPosition(){
        if(PlayerControls.joystick.Vertical > joystickUp && !PlayerControls.jumping){
            Level1.selectedCharacterCollider.enabled = false;
        }
        else if(PlayerControls.joystick.Vertical < joystickDown && !PlayerControls.jumping){
            Level1.selectedCharacterCollider.enabled = false;
            StartCoroutine(delay());
        }
        else if(Level1.selectedCharacterCollider.gameObject.GetComponent<Rigidbody2D>().velocity.y < -2f){
            Level1.selectedCharacterCollider.enabled = true;
        }
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(1f);
        Level1.selectedCharacterCollider.enabled = true;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "ThickPlatform"){
            Level1.selectedCharacterCollider.enabled = true;
        }
    }
}
