using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VideoScript : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
            DialogManager.Instance.Ondialogue(new string[] { "�ڳ� ���п� �ƹ����� �طʺ��� â�� ���Ǹ� ��ã�� �� �־���!",
            "�߱��� �� �ƴ� �ѱ��� �̿��� ���� �ļ��� �����ϴ� ������ ������ ���±���!","���� ����. ���� ����!","���̻� �ܰ��ο��� ���ѱ��� �ʵ��� �����ε� �ѱ��� ������ֱ� �ٶ��!"});
        gameObject.SetActive(false);

    }
}
