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
    /// ���콺 ����Ʈ�� ���� ���� ���η� �� �� 1ȸ ȣ��
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = new Color(color.r, color.g, color.b, 0.6f);
    }

    /// <summary>
	/// ���콺 ����Ʈ�������� �������� �� 1ȸ ȣ��
	/// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = new Color(color.r, color.g, color.b, 1);
    }


    /// <summary>
	/// ���� ������Ʈ�� �巡���ϱ� ������ �� 1ȸ ȣ��
	/// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.transform.position = eventData.position;
    }

    /// <summary>
	/// ���� ������Ʈ�� �巡�� ���� �� �� ������ ȣ��
	/// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        rect.transform.position = eventData.position;
    }

    /// <summary>
	/// ���� ������Ʈ�� �巡�׸� ������ �� 1ȸ ȣ��
	/// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        bool success = false;
        // ���ġ Ȥ�� ����
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
            // ���ġ
        }

    }

    /// <summary>
    /// ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
    }
}
