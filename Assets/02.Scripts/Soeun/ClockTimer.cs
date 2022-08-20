using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timeTxt;
    [SerializeField] Image clockImg;
    public float maxtime = 30;
    [SerializeField] Image warn;
    Coroutine timerCoroutine;


    void Start()
    {
        timerCoroutine = StartCoroutine(Timer());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            clockImg.fillAmount = 0;
            timeTxt.text = "";
            warn.enabled = false;
            TouchController.instance.IsEnd = true;
            KingMovement.instance.FindRoad();
        }
    }

    IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        float time = maxtime;

        while (time > 0)
        {
            yield return null;
            if (DialogManager.Instance != null)
            {
                if (DialogManager.Instance.isTutorial)
                {
                    yield return null;
                    continue;

                }
            }
            time--;
            if (time <= 0)
            {
                StopTimer();
                yield break;
            }
            clockImg.fillAmount = time / maxtime;
            timeTxt.text = time + "";

            if (time <= 10)
            {
                warn.enabled = !(time % 2 == 0);
            }

            yield return wait;
        }
    }

}
