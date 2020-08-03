using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DetailPage : MonoBehaviour
{
    public InputField titleText, contentText;
    public GameObject colorBoxRed,colorBoxOrange,colorBoxGreen;

    public SchedulePage schedulePage;

    private ScheduleItem bindingScheduleItem;
    private string boxColorString;
    private Color boxColor=Color.white;

    public void SetBoxColor(string colorName)
    {
        switch (colorName)
        {
            case "red":
                colorBoxRed.SetActive(true);
                colorBoxOrange.SetActive(false);
                colorBoxGreen.SetActive(false);
                boxColor = new Color(1f,0.5f,0.5f,0.5f);
                boxColorString = "red";
                break;
            case "orange":
                colorBoxRed.SetActive(false);
                colorBoxOrange.SetActive(true);
                colorBoxGreen.SetActive(false);
                boxColor = new Color(1f, 0.5f, 0f,0.5f);
                boxColorString = "orange";
                break;
            case "green":
                colorBoxRed.SetActive(false);
                colorBoxOrange.SetActive(false);
                colorBoxGreen.SetActive(true);
                boxColor = new Color(0.5f, 1f, 0.5f, 0.5f);
                boxColorString = "green";
                break;
        }
    }

    public void SetContent(string title,string content,string color,ScheduleItem scheduleItem)
    {
        titleText.text = title;
        contentText.text = content;
        bindingScheduleItem = scheduleItem;
        switch (color)
        {
            case "red":
                colorBoxRed.SetActive(true);
                colorBoxOrange.SetActive(false);
                colorBoxGreen.SetActive(false);
                break;
            case "orange":
                colorBoxRed.SetActive(false);
                colorBoxOrange.SetActive(true);
                colorBoxGreen.SetActive(false);
                break;
            case "green":
                colorBoxRed.SetActive(false);
                colorBoxOrange.SetActive(false);
                colorBoxGreen.SetActive(true);
                break;
        }
    }

    public void SetScheduleItemContent()
    {
        bindingScheduleItem.SetItemDispalyText(titleText.text,boxColor);
        bindingScheduleItem.title = titleText.text;
        bindingScheduleItem.content = contentText.text;
        bindingScheduleItem.completeness = boxColorString;
        boxColor = Color.white;
        colorBoxRed.SetActive(false);
        colorBoxOrange.SetActive(false);
        colorBoxGreen.SetActive(false);
    }

    public void BackLastPage()
    {
        schedulePage.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
