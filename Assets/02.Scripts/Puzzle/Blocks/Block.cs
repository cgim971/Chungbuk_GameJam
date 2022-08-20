using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // 연결 된 블록
    public List<Block> connectedBlock = new List<Block>();
    // 블록에 달려 있는 포인트들(circle collider)
    public List<Puzzle_Point> blockPoint = new List<Puzzle_Point>();


    public virtual int GetCost()
    {
        // 길이 하나임 걍 가
        if (connectedBlock.Count <= 1)
        {
            return 0;
        }

        return -1;
    }

}
