using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MarkController : MonoBehaviour
{
    public GameObject pointPrefab;
    public Transform m_markingPointParent;
    public Transform m_infoParent;
    public RectTransform mapLayer;
    public bool isMarking;

    private void Start()
    {
        Input.multiTouchEnabled = true;
    }

    private void Update()
    {
        //if (Input.GetMouseButton(2))
        //    mapLayer.localPosition = mapLayer.localPosition - new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * 800, Input.GetAxis("Mouse Y") * Time.deltaTime * 800, 0);
        mapLayer.localPosition = mapLayer.localPosition - (Vector3)Input.touches[0].deltaPosition* Time.deltaTime*20;
    }

    public void CreateMarkPoint()
    {
        GameObject obj = Instantiate(pointPrefab.gameObject, m_markingPointParent);
        obj.GetComponent<RectTransform>().position = (Vector3)Input.touches[0].position;
        obj.GetComponent<MarkPoint>().markController = this;

    }

    public void SetIsMarking(bool value)
    {
        isMarking = value;
    }

    public void LoadByIO()
    {
        double startTime = (double)Time.time;
        //创建文件读取流
        FileStream fileStream = new FileStream("map.jpg", FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);
        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        int width = 4000;
        int height = 4000;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        //创建Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        mapLayer.gameObject.GetComponent<Image>().sprite = sprite;

        startTime = (double)Time.time - startTime;
        Debug.Log("IO加载用时:" + startTime);

    }

    ////放大数值
    //float isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    //{
    //    float leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
    //    float leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
    //    return leng2 - leng1;
    //}
}
