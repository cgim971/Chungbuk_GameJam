using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{

    [SerializeField] private float _radius = 0.05f;
    [SerializeField] private List<CircleCollider2D> _circleCollider = new List<CircleCollider2D>();
    [SerializeField] private LayerMask _circleMask;


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
                        Debug.Log("있따");
                        Vector3 pos = col2.transform.position;
                        pos -= c.transform.localPosition / 2;

                        transform.position = pos;
                        return;
                    }
                }
            }

        }
    }


}
