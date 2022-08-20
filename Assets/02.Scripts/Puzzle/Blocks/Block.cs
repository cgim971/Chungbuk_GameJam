using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public List<Block> connectedBlock = new List<Block>();
    public List<Puzzle_Point> blockPoint = new List<Puzzle_Point>();


    public virtual int GetCost()
    {
        // ���� �ϳ��� �� ��
        if (connectedBlock.Count <= 1)
        {
            return 0;
        }

        return -1;
    }

}
