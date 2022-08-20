using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Triple : Block
{
    public override int GetCost()
    {
        int index = base.GetCost();
        if (index == 0)
        {
            return 0;
        }

        // 블록이 3개짜리면 자기 위치를 빼고 2개의 포인트가 남음
        int[] arr = new int[2];

        // 연결된 블록을 하나하나 검사
        for (int i = 0; i < connectedBlock.Count; i++)
        {
            // 검사 실행 
            arr[i] = connectedBlock[i].GetCost();

            for (int j = 0; j < blockPoint.Count; j++)
            {
                if (blockPoint[i]._isPlayer == true)
                {
                    if (j == 1)
                    {
                        if (blockPoint[0].connectedAncher != null)
                        {
                            arr[i] += 1;
                            break;
                        }
                        else if (blockPoint[2].connectedAncher != null)
                        {
                            arr[i] += 1;
                            break;
                        }
                    }
                    else
                    {
                        int dir = 1 - j;

                        if (blockPoint[j - dir].connectedAncher != null)
                        {
                            arr[i] += 1;
                        }
                    }
                }
            }
        }

        return 0;
    }

}
