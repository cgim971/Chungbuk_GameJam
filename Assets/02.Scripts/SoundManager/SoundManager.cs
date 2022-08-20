using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }


    public AudioClip[] bgList;

    public AudioSource bgSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
            Destroy(gameObject);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgList.Length; i++)
        {
            // ��� ����� �̸��� ���̸��� �����ϰ� ���߱�
            if(arg0.name== bgList[i].name)
                BgSoundPlay(bgList[i]); 
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject($"{sfxName} Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.volume = MusicVolumes.seVolume;
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }


    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;

        //���� ����
        bgSound.volume = MusicVolumes.bgmVolume;
        bgSound.Play();
    }
}
