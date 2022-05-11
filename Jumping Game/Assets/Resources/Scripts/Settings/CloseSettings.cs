using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CloseSettings : MonoBehaviour
{
    [SerializeField]
    private Button closeSettings;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;
    private string filePath;
    void Start()
    {
        closeSettings.onClick.AddListener(closeSettingsFunction);
    }
    void closeSettingsFunction()
    {
        Data.saveSettingsFunction(new Data(soundSlider.value, musicSlider.value));
        Debug.Log("Close settings page");
        // function to close settings
    }
}
