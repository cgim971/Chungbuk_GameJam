using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<StageInfo> _stageInfos = new List<StageInfo>();
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _point;

    [SerializeField] private GameObject _kingObj;

    private void Start()
    {

        // 이거 해야 함
        SetStage(0);
        TouchController.instance.IsEnd = false;
    }

    public void SetStage(int stageNumber)
    {
        if (stageNumber > _stageInfos.Count) return;

        StageInfo stageInfo = _stageInfos[stageNumber];

        CreatePoint(stageInfo._startPointInfo.pos, PointInfo.PointType.StartPoint);

        for (int i = 0; i < _stageInfos[stageNumber]._stagePointList.Count; i++)
        {
            CreatePoint(stageInfo._stagePointList[i].pos, PointInfo.PointType.MiddlePoint);
        }

        CreatePoint(stageInfo._endPointInfo.pos, PointInfo.PointType.EndPoint);

        GameObject king = Instantiate(_kingObj, null);
        king.transform.position = stageInfo._startPointInfo.pos;
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
    public int number;
    public Vector2 pos;
}