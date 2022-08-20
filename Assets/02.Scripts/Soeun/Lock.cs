using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public int CurrentStage;

    private void Start() {

        gameObject.SetActive(DataManager.Instance.data.stageClear[CurrentStage]);

    }
}
