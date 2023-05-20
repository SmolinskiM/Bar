using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputDetector : MonoBehaviour, IPointerClickHandler
{
    public Action onClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickEvent?.Invoke();
    }
}
