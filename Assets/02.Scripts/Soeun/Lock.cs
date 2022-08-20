using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public int CurrentStage;

    private void Start() {
        if (DataManager.Instance.data.stageClear[CurrentStage]) {
            gameObject.SetActive(false);
        }
    }
}
