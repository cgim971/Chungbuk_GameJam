using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeVolume : MonoBehaviour
{
    public AudioSource audiosource;
    [SerializeField] Slider slider;
    [SerializeField] Image image;
    [SerializeField] Sprite[] sprite = new Sprite[2];
    [SerializeField] TMP_Text text;
    public bool isBGM = false;

    private void Start() {
        OpenVolume();
    }


    public void OpenVolume() {
        if (isBGM) slider.value = DataManager.Instance.data.bgSoundVolume;
        else slider.value = DataManager.Instance.data.sfxSoundVolume;
        text.text = (int)(slider.value * 100) + "";
        audiosource.volume = slider.value;
    }

    public void SetVolume() {
        audiosource.volume = slider.value;
        text.text = (int)(slider.value * 100) + "";
        if (sprite[0] != null && sprite[1] != null) {
            if (slider.value <= 0) image.sprite = sprite[1];
            else image.sprite = sprite[0];
        }


    }

    public void SaveVolume() {
        if(isBGM) DataManager.Instance.data.bgSoundVolume = audiosource.volume;
        else DataManager.Instance.data.sfxSoundVolume = audiosource.volume;
    }

}
