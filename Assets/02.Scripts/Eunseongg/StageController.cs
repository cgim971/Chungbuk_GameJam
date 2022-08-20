using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public static StageController instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject clearPanel;
    public void Clear(int num)
    {
        DataManager.Instance.data.stageClear[num] = true;
        DataManager.Instance.Save();
        clearPanel.SetActive(true);
    }

}
