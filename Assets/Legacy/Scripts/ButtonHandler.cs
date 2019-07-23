using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private UnityEvent m_LeftClickEvent;
    [SerializeField]
    private UnityEvent m_RightClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left Clicked");
            m_LeftClickEvent.Invoke();

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right Clicked");
            m_RightClickEvent.Invoke();

        }
    }
}
