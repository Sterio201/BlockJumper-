using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;
    [SerializeField] Image button;

    [SerializeField] AudioType audioType;

    [SerializeField] bool randMusic;
    [SerializeField] AudioClip[] audioClips;

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

    public IEnumerator ShiftMusic(int id)
    {
        while(audioSource.volume != 0f)
        {
            audioSource.volume -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Debug.Log("Музыка сменилась");
        audioSource.clip = audioClips[id];

        while(audioSource.volume != 1f)
        {
            audioSource.volume += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}

enum AudioType {sound, music}