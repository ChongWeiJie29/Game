using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pot : MonoBehaviour, IDropHandler
{
    public static PointerEventData eventData;
    private GameObject[] listOfPowerUps = new GameObject[2]; 
    void Update()
    {
        mixPowerUps();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Pot.eventData = eventData;
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (listOfPowerUps[0] == null)
            {
                listOfPowerUps[0] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
            } 
            else
            {
                listOfPowerUps[1] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
            }
        }
    }

    public void mixPowerUps()
    {
        if (listOfPowerUps[1] != null)
        {
            Debug.Log("Mix powers");
        }
    }
}
