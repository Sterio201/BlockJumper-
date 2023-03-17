using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RailPlayer : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Transform[] rails;
    [SerializeField] Transform player;

    [SerializeField] float speed;

    bool readyShiftRail;
    int currentIdRail;

    private void OnEnable()
    {
        player.position = rails[1].position;

        readyShiftRail = true;
        currentIdRail = 1;
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        if (readyShiftRail)
        {
            if (eventData.delta.x > 0 && player.transform.position != rails[rails.Length - 1].position)
            {
                StartCoroutine(ShiftRail(1));
            }
            else if (eventData.delta.x < 0 && player.transform.position != rails[0].position)
            {
                StartCoroutine(ShiftRail(-1));
            }
        }
    }

    IEnumerator ShiftRail(int shift)
    {
        if (ObstacleGenerate.generate)
        {
            ScorePlayer.ShiftScore();
        }

        readyShiftRail = false;
        currentIdRail += shift;
        Vector3 newPos = rails[currentIdRail].position;

        while(player.position != newPos)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            player.position = Vector3.MoveTowards(player.position, newPos, speed * Time.deltaTime);
        }

        readyShiftRail = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log(1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(2);
    }
}