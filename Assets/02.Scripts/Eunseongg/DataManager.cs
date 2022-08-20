using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance { get { return instance; } }
    public UserData data = new UserData();

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        Load();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/Resources/Userdata.json",json);
    }

    public void Load()
    {
        TextAsset TA = Resources.Load<TextAsset>("Userdata");
        data = JsonUtility.FromJson<UserData>(TA.text);
    }
}
