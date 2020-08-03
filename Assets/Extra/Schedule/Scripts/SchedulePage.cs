using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchedulePage : MonoBehaviour
{
    public DetailPage detailPage;
    public GameObject scheduleItemPrefab;
    public Transform scheduleItemParent;

    public void AddItem()
    {
        GameObject item = Instantiate(scheduleItemPrefab, scheduleItemParent);
        item.GetComponent<ScheduleItem>().SetBindingDetailPage(detailPage,this);
    }

}
