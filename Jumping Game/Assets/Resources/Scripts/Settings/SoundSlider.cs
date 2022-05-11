using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    private Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        soundSlider.onValueChanged.AddListener(soundSliderFunction);
    }
    void soundSliderFunction(float soundValue)
    {
        Debug.Log(soundValue);
        //function to change volume
    }
}
