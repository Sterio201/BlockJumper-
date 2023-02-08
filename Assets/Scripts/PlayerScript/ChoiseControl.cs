using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseControl : MonoBehaviour
{
    [SerializeField] JumpPlayer jumpPlayer;
    [SerializeField] FlightPlayer flightPlayer;
    [SerializeField] RailPlayer railPlayer;

    [SerializeField] GameObject player;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Controller"))
        {
            int id = PlayerPrefs.GetInt("Controller");
            switch (id)
            {
                case 0:
                    jumpPlayer.enabled = true;
                    player.GetComponent<Animator>().enabled = true;
                    break;

                case 1:
                    flightPlayer.enabled = true;
                    break;

                case 2:
                    railPlayer.enabled = true;
                    break;
            }
        }
        else
        {
            jumpPlayer.enabled = true;
            player.GetComponent<Animator>().enabled = true;
        }
    }
}