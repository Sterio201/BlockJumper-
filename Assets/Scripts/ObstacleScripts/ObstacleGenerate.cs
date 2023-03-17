using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour
{
    [SerializeField] GameObject obsPrefab;
    [SerializeField] Transform[] rails;

    public static float timeGenerate;
    public static bool generate;

    float startX;

    private void Start()
    {
        timeGenerate = 0.65f;
    }

    public IEnumerator Generate(TypeControl typeControl)
    {
        startX = obsPrefab.transform.position.x;
        int rand = 0;
        float randScale = Random.Range(1.5f, 5);

        while (generate)
        {
            switch (typeControl)
            {
                case TypeControl.jump:
                    randScale = Random.Range(1.5f, 5);

                    if (rand == 0)
                    {
                        startX = -1.8f;
                        rand = 1;
                    }
                    else if (rand == 1)
                    {
                        startX = 1.8f;
                        rand = 0;
                    }

                    break;

                case TypeControl.flight:
                    randScale = 0.6f;
                    startX = Random.Range(-1.8f, 1.8f);
                    break;

                case TypeControl.rail:
                    randScale = Random.Range(0.8f, 3);

                    int randRail = Random.Range(0, 3);
                    startX = rails[randRail].localPosition.x;

                    break;

                default:
                    break;
            }

            SpawnObs(startX, randScale);

            yield return new WaitForSeconds(timeGenerate);
        }
    }

    void SpawnObs(float x, float scale)
    {
        GameObject newObs;

        if (ObstaclePool.obsPool.Count == 0)
        {
            newObs = Instantiate(obsPrefab);
        }
        else
        {
            newObs = ObstaclePool.obsPool.Pop();
        }

        Transform pos = newObs.GetComponent<Transform>();

        pos.localScale = new Vector3(pos.localScale.x, scale, pos.localScale.z);
        pos.position = new Vector3(x, 9, 0);

        newObs.SetActive(true);
        ObstaclePool.allObs.Add(newObs);
    }
}