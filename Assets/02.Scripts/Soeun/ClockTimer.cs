using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timeTxt;
    [SerializeField] Image clockImg;
    public float maxtime=30;
    [SerializeField] Image warn;
    Coroutine timerCoroutine;


    void Start() {
        timerCoroutine = StartCoroutine(Timer());

        
    }

    public void StopTimer() {
        if (timerCoroutine != null) {
            StopCoroutine(timerCoroutine);
            clockImg.fillAmount = 0;
            timeTxt.text = "";
            warn.enabled = false;

        }


    }

    IEnumerator Timer() {
        WaitForSeconds wait = new WaitForSeconds(1);
        float time = maxtime;

        while (time >0) {
            time--;
            if (time <= 0) {
                GameObject.FindGameObjectWithTag("GameOver").GetComponent<Canvas>().enabled = true;
            }
            clockImg.fillAmount = time / maxtime;
            timeTxt.text = time+"";

            if (time <= 10) {
                warn.enabled = time % 2 == 0 ? false : true;
            }

            yield return wait;
        }
        
    }


}
