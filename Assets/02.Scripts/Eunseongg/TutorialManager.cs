using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public string[] sentences;
    void Start()
    {
        if (DialogManager.Instance.dialogueGroup.alpha == 0)
            DialogManager.Instance.Ondialogue(sentences);
    }

    void Update()
    {
        
    }
}
