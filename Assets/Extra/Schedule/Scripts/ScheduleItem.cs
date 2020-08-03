using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleItem : MonoBehaviour
{
    public string title, content, completeness;

    public Text displayText;

    private UnityEngine.UI.Button selfButton;

    private DetailPage bindingDetailPage;
    private SchedulePage bindingSchedulePage;


    private void Start()
    {
        selfButton = GetComponent<UnityEngine.UI.Button>();
        selfButton.onClick.AddListener(delegate
        {
            bindingDetailPage.SetContent(title,content,completeness,this);
            bindingDetailPage.gameObject.SetActive(true);
            bindingSchedulePage.gameObject.SetActive(false);
        });
    }

    public void SetBindingDetailPage(DetailPage detailPage,SchedulePage schedulePage)
    {
        bindingDetailPage = detailPage;
        bindingSchedulePage = schedulePage;
    }

    public void SetItemDispalyText(string value,Color buttonColor)
    {
        displayText.text = value;
        selfButton.image.color = buttonColor;
    }

}
