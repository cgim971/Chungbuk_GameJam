using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInfo : MonoBehaviour
{
    public enum PointType
    {
        None = -1,
        StartPoint = 0,
        MiddlePoint = 1,
        EndPoint = 2,
    }

    [SerializeField] private PointType _pointType = PointType.None;
    public PointType POINTTYPE
    {
        get => _pointType;
        set => _pointType = value;
    }


    private void FixedUpdate()
    {
        if (_pointType == PointType.EndPoint)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("word"));
            if(col != null)
            {
                StageController.instance.Clear(0);
            }
        }
    }
        

}
