using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{

    public static KingMovement instance;

    [SerializeField] private List<WordScript> wordControllerList = new List<WordScript>();


    private void Start()
    {
        instance = this;
    }


    public void AddWord(WordScript word)
    {
        wordControllerList.Add(word);
    }

    public void DeleteWord(out GameObject obj)
    {
        if (wordControllerList.Count <= 0)
        {
            obj = null;
            return;
        }
        WordScript word = wordControllerList[wordControllerList.Count - 1];
        wordControllerList.Remove(word);

        obj = word.gameObject;
    }


    public void FindRoad()
    {
        int index = 0;
        foreach (WordScript word in wordControllerList)
        {
            for (int i = 0; i < word.CircleCollider.Count; i++)
            {
                word.CircleCollider[i].GetComponent<CircleInfo>().Number = index++;
            }
            index = 0;
        }





    }



}
