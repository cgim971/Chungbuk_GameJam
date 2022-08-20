using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;
    public bool isBGM;
    void Start()
    {
        AudioVolume();
    }

    public void AudioVolume() {
        if(isBGM) audiosource.volume = DataManager.Instance.data.bgSoundVolume;
        else audiosource.volume = DataManager.Instance.data.sfxSoundVolume;
    }

}
