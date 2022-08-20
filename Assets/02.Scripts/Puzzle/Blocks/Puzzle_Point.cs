using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Point : MonoBehaviour
{
    public Block connectedAncher;
    public bool _isPlayer = false;

    public void SetBlock(Block block)
    {
        connectedAncher = block;
    }

}
