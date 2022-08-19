using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.userSave.LoadData();
    }

    public int LoadIntData(string str, int data)
    {
        return PlayerPrefs.GetInt(str, data);
    }
    public float LoadFloatData(string str, float data)
    {
        return PlayerPrefs.GetFloat(str, data);
    }
    public string LoadStringData(string str, string data)
    {
        return PlayerPrefs.GetString(str, data);
    }
    public Vector2 LoadVector2Data(string str)
    {
        string data = PlayerPrefs.GetString(str, "");
        Vector2 datas = JsonConvert.DeserializeObject<Vector2>(str);
        return datas;
    }
    public List<bool> LoadListData(string str)
    {
        string data = PlayerPrefs.GetString(str, "");
        List<bool> datas = JsonConvert.DeserializeObject<List<bool>>(data);
        return datas;
    }


    public void SaveData(string str, int data)
    {
        PlayerPrefs.SetInt(str, data);
    }
    public void SaveData(string str, float data)
    {
        PlayerPrefs.SetFloat(str, data);
    }
    public void SaveData(string str, string data)
    {
        PlayerPrefs.SetString(str, data);
    }
    public void SaveData(string str, Vector2 data)
    {
        string jsonStr = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(str, jsonStr);
    }
    public void SaveData(string str, List<bool> datas)
    {
        string jsonStr = JsonConvert.SerializeObject(datas);
        PlayerPrefs.SetString(str, jsonStr);
    }


    public void DeleteData(string str)
    {
        PlayerPrefs.DeleteKey(str);
    }
}
