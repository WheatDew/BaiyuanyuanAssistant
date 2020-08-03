using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarkingPanel : MonoBehaviour, IPointerClickHandler
{
    public MarkController markController;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(markController.isMarking)
        markController.CreateMarkPoint();
    }
}
