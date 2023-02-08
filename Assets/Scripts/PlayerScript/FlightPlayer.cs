using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlightPlayer : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform bodyPlayer;
    [SerializeField] float speed;

    [SerializeField] float timerScore;
    float time;

    private void Start()
    {
        time = timerScore;
    }

    private void Update()
    {
        if (ObstacleGenerate.generate)
        {
            if (time <= 0)
            {
                ScorePlayer.ShiftScore();
                time = timerScore;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        bodyPlayer.position = Vector3.MoveTowards(bodyPlayer.position, mousePosition, speed);
    }
}