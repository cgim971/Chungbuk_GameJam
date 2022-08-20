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
        //int index = 0;
        //foreach (WordController word in wordControllerList)
        //{
        //    for (int i = 0; i < word.CircleCollider.Count; i++)
        //    {
        //        word.CircleCollider[i].GetComponent<CircleInfo>().Number = index++;
        //    }
        //    index = 0;
        //}

        StartCoroutine(Stage1());
    }

    public List<xyPos> _xyPos;
    IEnumerator Stage1()
    {
        for (int i = 0; i < _xyPos.Count; i++)
        {
            Vector2 target = new Vector2(_xyPos[i].x, _xyPos[i].y);

            float dist = Vector2.Distance(target, transform.position);

            while (dist > 0.05f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, 2f * Time.deltaTime);
                dist = Vector2.Distance(target, transform.position);
                yield return null;
            }
        }

        StageController.instance.Clear(1);
    }
}

[System.Serializable]
public class xyPos
{
    public float x;
    public float y;
}
