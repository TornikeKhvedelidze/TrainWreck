using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RawImageClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Button_SO OnClicked; 

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke();
    }
}
