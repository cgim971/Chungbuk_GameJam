using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public static TouchController instance;

    [SerializeField] private float _radius = 0.3f;
    [SerializeField] private LayerMask _wordLayer;
    [SerializeField] private LayerMask _mapLayer;
    [SerializeField] private LayerMask _wordMapLayer;

    [SerializeField] private Button _returnBtn;

    Collider2D _obj;
    private Vector2 _currentObjPos;

    Coroutine touchCoroutine;
    WordController word;

    private bool _isEnd = false;
    public bool IsEnd
    {
        get => _isEnd;
        set => _isEnd = value;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _returnBtn.onClick.AddListener(() => Return());
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

        Collider2D[] cols = Physics2D.OverlapCircleAll(mousePos, _radius, _wordLayer);
        foreach (Collider2D col in cols)
        {
            if (col.isTrigger == true)
            {
                _obj = col;
                continue;
            }
        }

        if (_obj == null)
        {
            yield break;
        }

        WordController word = _obj.GetComponent<WordController>();

        if (word.IsBatch == true)
        {
            _obj = null;
            yield break;
        }


        _currentObjPos = _obj.transform.position;

        Vector3 offset = _currentObjPos - (Vector2)mousePos;

        while (true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos += offset;
            mousePos.z = 0;
            _obj.transform.position = mousePos;

            yield return null;
        }
    }

    void TouchEnd()
    {
        if (_obj == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 마우스 위치 변경 필요
        Collider2D map = Physics2D.OverlapCircle(mousePos, _radius, _wordMapLayer);
        word = _obj.GetComponent<WordController>();

        if (map != null)
        {
            _obj = null;
            return;
        }

        map = Physics2D.OverlapCircle(mousePos, _radius, _mapLayer);
        if (map == null)
        {
            _obj.transform.position = _currentObjPos;
        }
        word.IsBatch = true;
        word.CurrentPos = _currentObjPos;

        word.FindCircle();
        _obj = null;

        return;
    }


    public void Return()
    {
        if (_isEnd) return;
        KingMovement.instance.DeleteWord(out GameObject obj);

        if (obj == null) return;

        WordController word = obj.GetComponent<WordController>();

        ReturnPos(obj, word.CurrentPos);
        word.IsBatch = false;
    }

    public void ReturnPos(GameObject obj, Vector2 pos)
    {
        obj.transform.position = pos;
    }
}
