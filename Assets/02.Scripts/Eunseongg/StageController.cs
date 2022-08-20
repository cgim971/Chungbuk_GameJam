using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        try
        {
        DataManager.Instance.data.stageClear[num] = true;
        DataManager.Instance.Save();
        }
        catch
        {

        }

        clearPanel.SetActive(true);

    }


}
