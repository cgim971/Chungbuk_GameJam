using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeMoveSpeed : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static int moveSpeed=1;//���߿� ���� ������ �ӵ��� ���սô�
    int page = 0;//0=1��� 1=2��� 2=4���


    public void ChangeSpeed() {
        page++;
        if (page > 2) page = 0;

        if (page.Equals(0)) moveSpeed = 1;
        if (page.Equals(1)) moveSpeed = 2;
        if (page.Equals(2)) moveSpeed = 4;

        text.text = moveSpeed + ".0x >>";
    }




}
