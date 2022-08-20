using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    [SerializeField] private float _radius = 0.05f;
    [SerializeField] private List<CircleCollider2D> _circleCollider = new List<CircleCollider2D>();
    public List<CircleCollider2D> CircleCollider
    {
        get => _circleCollider;
        set => _circleCollider = value;
    }

    [SerializeField] private LayerMask _circleMask;

    [SerializeField] private Vector2 _currentPos;
    public Vector2 CurrentPos
    {
        get => _currentPos;
        set => _currentPos = value;
    }

    [SerializeField] private bool _isBatch;
    public bool IsBatch
    {
        get => _isBatch;
        set => _isBatch = value;
    }

    public void FindCircle()
    {
        foreach (CircleCollider2D c in _circleCollider)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(c.transform.position, _radius, _circleMask);

            foreach (Collider2D col2 in col)
            {
                if (col2.transform.parent != c.transform.parent)
                {
                    if (col2 != null)
                    {
                        // 붙음
                        Vector3 pos = col2.transform.position;
                        pos -= c.transform.localPosition * 1;

                        transform.position = pos;

                        // 퍼즐 포인트에 블록을 넣는다.
                        col2.GetComponent<Puzzle_Point>().SetBlock(this.GetComponent<Block>());


                        KingMovement.instance.AddWord(this);

                        return;
                    }
                }
            }

        }

        IsBatch = false;
        TouchController.instance.ReturnPos(this.gameObject, CurrentPos);
    }



}
