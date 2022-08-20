using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    private static PuzzleController instance;
    public static PuzzleController Instance { get { return instance; } }

    [SerializeField] private float _radius = 0.3f;
    [SerializeField] private LayerMask _wordLayer;
    [SerializeField] private LayerMask _mapLayer;
    [SerializeField] private LayerMask _wordMapLayer;

    Coroutine touchCoroutine;

    public GameObject currentDragObject;

    public WordScript currentWord;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        // _returnBtn.onClick.AddListener(() => Return());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchCoroutine = StartCoroutine(Touching());
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (touchCoroutine != null)
            {
                TouchEnd();
                StopCoroutine(touchCoroutine);
            }
        }
    }

    IEnumerator Touching()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"{ mousePos.x}, {0}, {mousePos.z}");

        Collider[] cols = Physics.OverlapSphere(new Vector3(mousePos.x, 0, mousePos.z), _radius, _wordLayer);
        yield return null;
        foreach (Collider col in cols)
        {
            Debug.Log(col.name);
            if (col.isTrigger == true)
            {
                Debug.Log("Found");
                currentDragObject = col.gameObject;
            }
        }

        if (currentDragObject == null)
        {
            Debug.Log("not exsit");
            yield break;
        }

        WordScript word = currentDragObject.GetComponent<WordScript>();

        /*
        if (word.IsBatch == true)
        {
            _obj = null;
            yield break;
        }*/


        Vector3 _currentObjPos = currentDragObject.transform.position;

        Vector3 offset = _currentObjPos - (Vector3)mousePos;

        while (true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos += offset;
            //mousePos.y = 0;
            currentDragObject.transform.position = mousePos;

            yield return null;
        }
    }

    void TouchEnd()
    {
        if (currentDragObject == null) return;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // 마우스 위치 변경 필요
        Collider2D map = Physics2D.OverlapCircle(mousePos, _radius, _wordMapLayer);
        currentWord = currentDragObject.GetComponent<WordScript>();

        if (map != null)
        {
            currentDragObject = null;
            return;
        }

        map = Physics2D.OverlapCircle(mousePos, _radius, _mapLayer);
        if (map == null)
        {
            currentDragObject.transform.position = currentDragObject.transform.position;
        }
        currentWord.Current = _currentObjPos;

        currentWord.FindCircle();
        _obj = null;

        return;
    }



}
