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
    
    int idGenerate;

    private void Start()
    {
        generate = true;
        timeGenerate = 0.65f;

        if (PlayerPrefs.HasKey("Controller"))
        {
            idGenerate = PlayerPrefs.GetInt("Controller");
        }
        else
        {
            idGenerate = 1;
        }
    }

    public void StartGenerate()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        startX = obsPrefab.transform.position.x;
        int rand = 0;
        float randScale = Random.Range(1.5f, 5);

        while (generate)
        {
            switch (idGenerate)
            {
                case 0:
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

                case 1:
                    randScale = 0.6f;
                    startX = Random.Range(-1.8f, 1.8f);
                    Debug.Log(startX);
                    break;

                case 2:
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