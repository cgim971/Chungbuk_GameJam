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
    
    public Image locker;
    public Image img;
    public Text txt;
    public Cloth[] clothes;
    public Button btn;
    public GameObject obj;
    int page = 0;

    private void Start() {
        PrepareCloth();
    }
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
        locker.enabled = !UserSave.haveSkin[page];
        btn.interactable= !UserSave.haveSkin[page];
    }

    public void UseSkin() {
        UserSave.currentSkin = page;
        obj.SetActive(true);
    }
}
