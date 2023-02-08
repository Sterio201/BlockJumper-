using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject panelEnd;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] MyTargetManager myTarget;

    private void Start()
    {
        particleSystem.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        if (PlayerPrefs.HasKey("target"))
        {
            int countGame = PlayerPrefs.GetInt("target");
            countGame++;

            if(countGame >= 2)
            {
                countGame = 0;
                myTarget.Show();
            }

            PlayerPrefs.SetInt("target", countGame);
        }
        else
        {
            PlayerPrefs.SetInt("target", 0);
        }

        audioSource.PlayOneShot(audioClip);
        ObstacleMove.moving = false;
        ObstacleGenerate.generate = false;

        spriteRenderer.color = new Color(0f,0f,0f,0f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;

        particleSystem.Play();
        yield return new WaitForSeconds(0.6f);
        panelEnd.SetActive(true);
    }
}