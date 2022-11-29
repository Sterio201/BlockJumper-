using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public static float speed;
    public static bool moving;

    private void Start()
    {
        moving = true;
        speed = 8f;
    }

    void Update()
    {
        if (moving)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        } 
    }
}