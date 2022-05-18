using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Pot : MonoBehaviour, IDropHandler
{
    public static PointerEventData eventData;
    private CanvasGroup canvas;
    private GameObject[] listOfPowerUps = new GameObject[2]; 
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        mixPowerUps();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Pot.eventData = eventData;
        if (eventData.pointerDrag != null)
        {
            canvas.alpha = 1;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = PowerUps.initialPos;
            if (listOfPowerUps[0] == null)
            {
                listOfPowerUps[0] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
            } 
            else
            {
                listOfPowerUps[1] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
            }
        }
        else
        {
            canvas.alpha = 1;
        }
    }

    public void mixPowerUps()
    {
        if (listOfPowerUps[1] != null)
        {
            Debug.Log("Mix powers");
            Array.Clear(listOfPowerUps, 0, listOfPowerUps.Length);
        }
    }
}
