/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadLevels : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelButton;
    public int levelQty = 20;

    private void Start(){
        for(int i=0; i<levelQty; i++){
            GameObject newButton = Instantiate(levelButton, levelHolder.transform) as GameObject;
            newButton.name = "Level " + (i+1);
            newButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + (i+1));
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadLevels : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelButton;
    public int levelQty = 20;
    public int levelUnlocked = 1;

    private void Start(){
        for(int i=1; i<=levelQty; i++){
            GameObject newButton = Instantiate(levelButton, levelHolder.transform) as GameObject;
            if(i <= levelUnlocked){
                newButton.name = "Level " + i;
                newButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + i);
                newButton.GetComponent<Button>().interactable = true;
                Debug.Log("true" + i);
            }else{
                newButton.name = "Level " + i + " Locked";
                newButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + i + "\nLocked");
                newButton.GetComponent<Button>().interactable = false;
                Debug.Log("false" + i);
            }
        }
    }
}