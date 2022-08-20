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

        int[] arr = new int[2];

        for (int i = 0; i < connectedBlock.Count; i++)
        {
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

                        }
                    }
                }
            }
        }

        return 0;
    }

}
