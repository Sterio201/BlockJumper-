using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftControllerMovePlayer : MonoBehaviour
{
    [SerializeField] JumpPlayer jumpPlayer;
    [SerializeField] FlightPlayer flightPlayer;

    TypeMove typeMove;

    private void Start()
    {
        jumpPlayer.enabled = true;
        flightPlayer.enabled = false;

        typeMove = TypeMove.jump;
    }

    /*public IEnumerator ShiftController()
    {

    }*/
}

public enum TypeMove {jump, flight, rail}