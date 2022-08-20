using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Cloth {
    public string names;
    public Sprite sprite;
   
}


public class ClothTab : MonoBehaviour
{
    public Image img;
    public Text txt;
    public Cloth[] clothes;
    public Button btn;
    int page = 0;


    public void Right() {
        page++;
        if (page >= clothes.Length) page = 0;
        PrepareCloth();
    }

    public void Left() {
        page--;
        if (page < 0) page = clothes.Length - 1;
        PrepareCloth();
    }


    void PrepareCloth() {
        img.sprite = clothes[page].sprite;
        txt.text = clothes[page].names;
    }
}
