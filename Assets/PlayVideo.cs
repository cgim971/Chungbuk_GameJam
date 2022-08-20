using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    //[SerializeField] VideoPlayer vp;
    [SerializeField] Canvas can;
    

    private void Start() {
        StartCoroutine(HideVideo());

    }

    IEnumerator HideVideo() {
        yield return new WaitForSeconds(5);
        can.enabled = false;
    }

}
