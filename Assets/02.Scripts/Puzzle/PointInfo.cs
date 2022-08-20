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


}
