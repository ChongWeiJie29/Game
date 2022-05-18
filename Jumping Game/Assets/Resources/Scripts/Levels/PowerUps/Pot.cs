using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Pot : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static PointerEventData eventData;
    private CanvasGroup canvas;
    private GameObject[] listOfPowerUps = new GameObject[3]; 
    private Animator potAnim;
    private RectTransform potTransform;
    private Vector2 initialPos;
    private bool drag = false;
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        potAnim = GetComponent<Animator>();
        potAnim.SetFloat("fractionOfPotions", 0);
        potTransform = GetComponent<RectTransform>();
        initialPos = potTransform.anchoredPosition;

    }
    void Update()
    {
        // Debug.Log(drag);
    }
    public void OnDrop(PointerEventData eventData)
    {
        Pot.eventData = eventData;
        if (eventData.pointerDrag != null && !drag)
        {
            canvas.alpha = 1;
            if (listOfPowerUps[0] == null)
            {
                listOfPowerUps[0] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                potAnim.SetFloat("fractionOfPotions", (float)1/3);
            } 
            else if (listOfPowerUps[0] != null && listOfPowerUps[1] == null)
            {
                listOfPowerUps[1] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                potAnim.SetFloat("fractionOfPotions", (float)2/3);
            }
            else if (listOfPowerUps[0] != null && listOfPowerUps[1] != null)
            {
                listOfPowerUps[2] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                potAnim.SetFloat("fractionOfPotions", (float)1);
            }
        }
        else
        {
            canvas.alpha = 0.5f;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (listOfPowerUps[1] != null)
        {
            canvas.alpha = 1;
            potTransform.anchoredPosition += eventData.delta;
        }
    }
    public  void OnBeginDrag(PointerEventData eventData)
    {
        drag = true;
        if (listOfPowerUps[1] != null)
        {
            
        }
    }
    public  void OnPointerDown(PointerEventData eventData)
    {
        if (listOfPowerUps[1] != null)
        {
            
        }
    }
    public  void OnEndDrag(PointerEventData eventData)
    {
        if (listOfPowerUps[1] != null)
        {
            canvas.alpha = 0.5f;   
        }
        drag = false;
    }
}
