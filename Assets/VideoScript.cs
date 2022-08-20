using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VideoScript : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
            DialogManager.Instance.Ondialogue(new string[] { "자네 덕분에 훈민정음 해례본의 창제 의의를 되찾을 수 있었어!",
            "중국의 언어가 아닌 한글을 이용할 나의 후손을 생각하니 저절로 웃음이 나는구나!","정말 고맙네. 정말 고마워!","더이상 외계인에게 빼앗기지 않도록 앞으로도 한글을 사랑해주길 바라네!"});
        gameObject.SetActive(false);

    }
}
