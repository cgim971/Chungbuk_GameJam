using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerDownHandler
{

    private static DialogManager instance;
    public static DialogManager Instance { get { return instance; } }

    public GameObject obj;

    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialogueGroup;

    public Queue<string> sentences = new Queue<string>();

    public string currnetSentence;

    public float typingSpeed  = 0.1f;
    bool isTyping;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    } 

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        dialogueGroup.alpha = 1;
        dialogueGroup.blocksRaycasts = true;
        
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currnetSentence = sentences.Dequeue();
            isTyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currnetSentence));
        }
        else
        {
            dialogueGroup.alpha = 0;
            dialogueGroup.blocksRaycasts = false;
        }
    }


    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())  
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        // 대사 한줄 끝
        if (dialogueText.text.Equals(currnetSentence))
        {
            nextText.SetActive(true);
            isTyping=false; 
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isTyping)
            NextSentence();
    }
}
