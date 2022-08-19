using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeMoveSpeed : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static int moveSpeed=1;//나중에 세종 움직임 속도에 곱합시다
    int page = 0;//0=1배속 1=2배속 2=4배속


    public void ChangeSpeed() {
        page++;
        if (page > 2) page = 0;

        if (page.Equals(0)) moveSpeed = 1;
        if (page.Equals(1)) moveSpeed = 2;
        if (page.Equals(2)) moveSpeed = 4;

        text.text = moveSpeed + ".0x >>";
    }




}
