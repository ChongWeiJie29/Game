using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(musicSliderFunction);
    }
    void musicSliderFunction(float musicValue)
    {
        Debug.Log(musicValue);
        //function to change volume
    }
}
