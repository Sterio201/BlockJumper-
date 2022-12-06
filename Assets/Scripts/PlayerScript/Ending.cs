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
        audioSource.PlayOneShot(audioClip);
        ObstacleMove.moving = false;
        ObstacleGenerate.generate = false;

        spriteRenderer.color = new Color(0f,0f,0f,0f);

        particleSystem.Play();
        yield return new WaitForSeconds(0.6f);
        panelEnd.SetActive(true);
    }
}