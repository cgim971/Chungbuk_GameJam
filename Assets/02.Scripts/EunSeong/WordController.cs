using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WordController : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Image img;
    Color color;
    public RectTransform rect;

    public PointController[] points;
    void Start()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        points = GetComponentsInChildren<PointController>();
        color = img.color;
        int num = 0;
        foreach (PointController point in points)
        {
            point.pivotNumber = num++;
        }
    }
    /// <summary>
    /// 마우스 포인트가 현재 영역 내부로 들어갈 때 1회 호출
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = new Color(color.r, color.g, color.b, 0.6f);
    }

    /// <summary>
	/// 마우스 포인트가영역을 빠져나갈 때 1회 호출
	/// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = new Color(color.r, color.g, color.b, 1);
    }


    /// <summary>
	/// 현재 오브젝트를 드래그하기 시작할 때 1회 호출
	/// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.transform.position = eventData.position;
    }

    /// <summary>
	/// 현재 오브젝트를 드래그 중일 때 매 프레임 호출
	/// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        rect.transform.position = eventData.position;
    }

    /// <summary>
	/// 현재 오브젝트의 드래그를 종료할 때 1회 호출
	/// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        bool success = false;
        // 재배치 혹은 연결
        foreach (PointController point in points)
        {

            success = point.ConnectedCheck();
            if (success)
                break;
        }

        if (success)
        {
            GameObject obj = Instantiate(points[0].temp, Camera.main.ScreenToWorldPoint(rect.position), Quaternion.identity);
            obj.transform.position = Camera.main.ScreenToWorldPoint(rect.position);
            gameObject.SetActive(false);
        }
        else
        {
            // 재배치
        }

    }

    /// <summary>
    /// 현재 영역 내부에서 드롭을 했을 때 1회 호출
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
    }
}
