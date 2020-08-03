using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public GameObject Schedule;
    public GameObject TradeAgency;
    public GameObject ButtonParent;

    public void SetSchedule()
    {
        ButtonParent.SetActive(false);
        Schedule.SetActive(true);
    }

    public void SetTradeAgency()
    {
        ButtonParent.SetActive(false);
        TradeAgency.SetActive(true);
    }

    public void ReturnMain()
    {
        Schedule.SetActive(false);
        TradeAgency.SetActive(false);
        ButtonParent.SetActive(true);
    }
}
