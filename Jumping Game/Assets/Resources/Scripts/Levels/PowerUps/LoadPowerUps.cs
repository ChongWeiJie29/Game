using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadPowerUps : MonoBehaviour
{
    private int selectedCharacter = 0;
    private string selectedPowerUps;
    private GameObject powerUps;
    // Start is called before the first frame update
    void Start()
    {
        loadPowerUps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadPowerUps()
    {
        // selectedCharacter = CharacterContainer.selectedCharacter;
        switch(selectedCharacter)
            {
                case 0:
                    selectedPowerUps = "Scientists";
                    break;
                case 1:
                    selectedPowerUps = "";
                    break;
                case 2:
                    selectedPowerUps = "";
                    break;
                case 3:
                    selectedPowerUps = "";
                    break;
                case 4:
                    selectedPowerUps = "";
                    break;  
            }
        for (int i = 1; i <= 4; i++)
        {
            switch(i)
            {
                case 1:
                    powerUps = Instantiate(Resources.Load($"Assets/Characters/{selectedPowerUps}/Power1"), transform.position, Quaternion.identity) as GameObject;
                    powerUps.transform.SetParent(GameObject.Find("PowerUps").GetComponent<Transform>());
                    powerUps.transform.localScale = new Vector3(2, 2, 0);
                    break;
                case 2:
                    powerUps = Instantiate(Resources.Load($"Assets/Characters/{selectedPowerUps}/Power2"), transform.position, Quaternion.identity) as GameObject;
                    powerUps.transform.SetParent(GameObject.Find("PowerUps").GetComponent<Transform>());
                    powerUps.transform.localScale = new Vector3(2, 2, 0);
                    break;
                case 3:
                    powerUps = Instantiate(Resources.Load($"Assets/Characters/{selectedPowerUps}/Power3"), transform.position, Quaternion.identity) as GameObject;
                    powerUps.transform.SetParent(GameObject.Find("PowerUps").GetComponent<Transform>());
                    powerUps.transform.localScale = new Vector3(2, 2, 0);
                    break;
                case 4:
                    powerUps = Instantiate(Resources.Load($"Assets/Characters/{selectedPowerUps}/Pot"), transform.position, Quaternion.identity) as GameObject;
                    powerUps.transform.SetParent(GameObject.Find("PowerUps").GetComponent<Transform>());
                    powerUps.transform.localScale = new Vector3(2, 2, 0);
                    break;    
            }
        }
    }
}
