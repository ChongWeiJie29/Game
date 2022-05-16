using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Level1");
        // function to stay playing
    }
}
