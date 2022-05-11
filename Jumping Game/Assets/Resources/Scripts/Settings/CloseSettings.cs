using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettings : MonoBehaviour
{
    [SerializeField]
    private Button closeSettings;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;
    void Start()
    {
        closeSettings.onClick.AddListener(closeSettingsFunction);
    }
    void closeSettingsFunction()
    {
        Debug.Log(soundSlider.value);
        Debug.Log(musicSlider.value);
        Debug.Log("Close settings page");
        // function to close settings
    }
}
