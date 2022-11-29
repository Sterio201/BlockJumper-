using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPlayer : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    Animator animator;
    Pos pos;

    bool readyJump;

    private void Start()
    {
        ScorePlayer.score = 0;

        animator = GetComponent<Animator>();
        pos = Pos.right;
        readyJump = true;
    }

    public void JumpActivate()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        if (readyJump)
        {
            audioSource.PlayOneShot(audioClip);

            ScorePlayer.score++;
            scoreText.text = ScorePlayer.score.ToString();

            if(ScorePlayer.score%20 == 0 && ScorePlayer.score != 0 && ScorePlayer.score <= 60)
            {
                ObstacleMove.speed += 4f;
                ObstacleGenerate.timeGenerate -= 0.12f;
            }

            readyJump = false;
            string nameAnim;

            if (pos == Pos.right)
            {
                nameAnim = "JumpLeft";
                pos = Pos.left;
            }
            else
            {
                nameAnim = "JumpRight";
                pos = Pos.right;
            }

            animator.Play(nameAnim);
            yield return new WaitForSeconds(0.2f);
            readyJump = true;
        }
    }
}

public enum Pos {left, right }