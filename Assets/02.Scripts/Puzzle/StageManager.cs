using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private StageInfo _stageInfo;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _point;

    [SerializeField] private GameObject _kingObj;

    public static StageManager instance;
    public int number;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        // 이거 해야 함
        SetStage();
        TouchController.instance.IsEnd = false;
    }

    public void SetStage()
    {
        CreatePoint(_stageInfo._startPointInfo.pos, PointInfo.PointType.StartPoint);

        for (int i = 0; i < _stageInfo._stagePointList.Count; i++)
        {
            CreatePoint(_stageInfo._stagePointList[i].pos, PointInfo.PointType.MiddlePoint);
        }

        CreatePoint(_stageInfo._endPointInfo.pos, PointInfo.PointType.EndPoint);

        GameObject king = Instantiate(_kingObj, null);
        king.transform.position = _stageInfo._startPointInfo.pos;
    }

    public void CreatePoint(Vector2 pos, PointInfo.PointType pointType)
    {
        GameObject newPoint = Instantiate(_point, _parent);
        newPoint.transform.position = pos;
        newPoint.GetComponent<PointInfo>().POINTTYPE = pointType;
    }
}


[System.Serializable]
public class StageInfo
{
    public StagePointInfo _startPointInfo = new StagePointInfo();
    public List<StagePointInfo> _stagePointList = new List<StagePointInfo>();
    public StagePointInfo _endPointInfo = new StagePointInfo();

}

[System.Serializable]
public class StagePointInfo
{
    public Vector2 pos;
}