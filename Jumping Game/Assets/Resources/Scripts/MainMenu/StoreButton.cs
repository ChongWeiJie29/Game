using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreButton : MonoBehaviour
{
    [SerializeField]
    private Button storeButton;
    void Start()
    {
        storeButton.onClick.AddListener(store);
    }

    void store()
    {
            Debug.Log("Store");
        // function to go to Store page
    }
}
