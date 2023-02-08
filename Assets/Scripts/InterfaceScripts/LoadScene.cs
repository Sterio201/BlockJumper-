using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int nomerScene;
    [SerializeField] PlayableDirector playable;

    AsyncOperation asyncOperation;

    public void Loading()
    {
        if(playable != null)
        {
            StartCoroutine(Animation());
        }
        else
        {
            SceneManager.LoadScene(nomerScene);
        }
    }

    IEnumerator Animation()
    {
        playable.Play();
        yield return new WaitForSeconds(0.5f);
        asyncOperation = SceneManager.LoadSceneAsync(nomerScene);
    }
}