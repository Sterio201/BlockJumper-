using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject buttonContinue;

    private void OnApplicationFocus(bool focus)
    {
        Time.timeScale = 0f;
        buttonContinue.SetActive(true);
        panelPause.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        //Application.Quit();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}