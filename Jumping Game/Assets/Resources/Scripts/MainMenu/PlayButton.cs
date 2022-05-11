using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(play);
    }

    void play()
    {
            Debug.Log("play");
        // function to stay playing
    }
}
