using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private float _radius = 0.3f;
    [SerializeField] private LayerMask _wordLayer;
    [SerializeField] private LayerMask _mapLayer;
    [SerializeField] private LayerMask _wordMapLayer;

    Collider2D _obj;
    private Vector2 _currentObjPos;

    Coroutine touchCoroutine;

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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 마우스 위치 변경 필요
        Collider2D map = Physics2D.OverlapCircle(mousePos, _radius, _wordMapLayer);
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
        _obj.GetComponent<WordController>().FindCircle();
        _obj = null;

        return;
    }


}
