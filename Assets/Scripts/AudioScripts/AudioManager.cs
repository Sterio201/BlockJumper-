using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    [SerializeField] Image button;

    [SerializeField] AudioType audioType;

    private void Start()
    {
        if (PlayerPrefs.HasKey(audioType.ToString()))
        {
            if(PlayerPrefs.GetInt(audioType.ToString()) == 0)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = 1;
            }
        }
        else
        {
            audioSource.volume = 1;
            PlayerPrefs.SetInt(audioType.ToString(), 1);
        }

        if (button != null)
        {
            if (audioSource.volume == 1)
            {
                button.sprite = audioOn;
            }
            else
            {
                button.sprite = audioOff;
            }
        }
    }

    public void AudioButton()
    {
        if(audioSource.volume == 1)
        {
            PlayerPrefs.SetInt(audioType.ToString(), 0);
            audioSource.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt(audioType.ToString(), 1);
            audioSource.volume = 1;
        }

        if(button != null)
        {
            if (audioSource.volume == 1)
            {
                button.sprite = audioOn;
            }
            else
            {
                button.sprite = audioOff;
            }
        }
    }
}

enum AudioType {sound, music}