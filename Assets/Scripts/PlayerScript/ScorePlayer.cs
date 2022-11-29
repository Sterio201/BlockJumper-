using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField] Text textScore;
    public static int score;

    public void ShiftScore()
    {
        score++;
        if(textScore.gameObject != null)
        {
            textScore.text = score.ToString();
        }
    }
}
