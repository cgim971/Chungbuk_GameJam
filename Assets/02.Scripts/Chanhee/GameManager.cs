using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{

    public SaveManager saveManager { get; private set; }
    public UserSave userSave { get; private set; }

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        userSave = FindObjectOfType<UserSave>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            userSave.ResetData();
        }
    }

}
