using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarkPoint : MonoBehaviour, IPointerClickHandler
{
    public MarkController markController;
    public GameObject panel; 


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!markController.isMarking)
        {
            panel.transform.parent = markController.m_infoParent;

            if (panel.activeSelf)
                panel.SetActive(false);
            else
                panel.SetActive(true);
        }
    }
}
