using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField] Text textScore;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    public static Text textScoreStatic;
    static AudioSource audioSourceStatic;
    static AudioClip audioClipStatic;
    static int score;

    private void Start()
    {
        score = 0;

        textScoreStatic = textScore;
        audioSourceStatic = audioSource;
        audioClipStatic = audioClip;
    }

    public static void ShiftScore()
    {
        score++;
        if(textScoreStatic.gameObject != null)
        {
            textScoreStatic.text = score.ToString();

            audioSourceStatic.PlayOneShot(audioClipStatic);

            if (score % 20 == 0 && score != 0 && score <= 60)
            {
                ObstacleMove.speed += 1f;
                ObstacleGenerate.timeGenerate -= 0.05f;
            }
        }
    }
}
