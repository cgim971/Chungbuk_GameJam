using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{

    public static KingMovement instance;

    [SerializeField] private List<WordController> wordControllerList = new List<WordController>();


    private void Start()
    {
        instance = this;
    }


    public void AddWord(WordController word)
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
        WordController word = wordControllerList[wordControllerList.Count - 1];
        wordControllerList.Remove(word);

        obj = word.gameObject;
    }



    public void FindRoad()
    {






    }




}
