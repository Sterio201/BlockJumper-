using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [HideInInspector]
    public static Stack<GameObject> obsPool;
    [HideInInspector]
    public static List<GameObject> allObs;

    private void Start()
    {
        obsPool = new Stack<GameObject>();
        allObs = new List<GameObject>();
    }

    private void Update()
    {
        for (int i = 0; i < allObs.Count; i++)
        {
            if (allObs[i].transform.position.y <= -9)
            {
                allObs[i].SetActive(false);
                obsPool.Push(allObs[i]);
                allObs.RemoveAt(i);
            }
        }
    }
}