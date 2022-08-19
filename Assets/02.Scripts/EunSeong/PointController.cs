using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PointController : MonoBehaviour
{

    RectTransform rect;
    public float radius = 5f;
    public LayerMask wordPointMask;
    public WordType type;
    public int pivotNumber;
    public GameObject parentObject;
    public GameObject temp;
    Vector3 worldPos;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void ConnectedCheck()
    {
        Debug.Log($"ConnectedCheck: {gameObject.name}");
        worldPos = Camera.main.ScreenToWorldPoint(rect.position);

        Collider2D c =  Physics2D.OverlapCircle(worldPos, radius, wordPointMask);
        if (c != null)
        {
            WordObject obj = Instantiate(temp, c.gameObject.transform.position, Quaternion.identity).GetComponent<WordObject>();
            obj.pivot[pivotNumber].transform.parent = null;
            obj.transform.parent = obj.pivot[pivotNumber].transform;
            obj.pivot[pivotNumber].transform.position = c.transform.position;
            //parentObject.SetActive(false);
        }
            
    }


}
