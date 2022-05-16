using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{
    [SerializeField]
    private Button selectLevelButton;
    void Start()
    {
        selectLevelButton.onClick.AddListener(selectLevel);
    }

    void selectLevel()
    {
            Debug.Log("selectLevel");
        // function to go to select level page
    }
}
