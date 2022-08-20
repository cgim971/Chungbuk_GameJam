using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public string[] sentences;
    void Start()
    {
        if(DialogManager.Instance.dialogueGroup.alpha == 0)
        DialogManager.Instance.Ondialogue(sentences);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
