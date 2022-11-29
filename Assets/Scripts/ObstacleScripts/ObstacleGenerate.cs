using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour
{
    [SerializeField] ObstaclePool pool;
    [SerializeField] GameObject obsPrefab;

    public static float timeGenerate;
    public static bool generate;

    Direction direction;

    float startX;

    private void Start()
    {
        generate = true;
        timeGenerate = 0.65f;
    }

    public void StartGenerate()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        startX = obsPrefab.transform.position.x;
        direction = Direction.right;

        while (generate)
        {
            float randSize = Random.Range(1.5f, 5);
            GameObject newObs;

            if (pool.obsPool.Count == 0)
            {
                newObs = Instantiate(obsPrefab);
            }
            else
            {
                newObs = pool.obsPool.Pop();
            }

            pool.allObs.Add(newObs);
            Transform pos = newObs.GetComponent<Transform>();
            
            pos.localScale = new Vector3(pos.localScale.x, randSize, pos.localScale.z);

            if (direction == Direction.right)
            {
                pos.position = new Vector3(-startX, 9, 0);
                direction = Direction.left;
            }
            else
            {
                pos.position = new Vector3(startX, 9, 0);
                direction = Direction.right;
            }

            yield return new WaitForSeconds(timeGenerate);
        }
    }
}

enum Direction {right, left }