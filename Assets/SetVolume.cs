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
        if(isBGM) audiosource.volume = MusicVolumes.bgmVolume;
        else audiosource.volume = MusicVolumes.seVolume;
    }

}
