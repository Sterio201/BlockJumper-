using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftController : MonoBehaviour
{
    [SerializeField] JumpPlayer jumpPlayer;
    [SerializeField] FlightPlayer flightPlayer;
    [SerializeField] RailPlayer railPlayer;

    [SerializeField] ObstacleGenerate obs;

    [SerializeField] GameObject player;
    [SerializeField] SkinsPlayer skins;

    [SerializeField] AudioManager shiftMusic;

    [SerializeField] Text alertText;
    [SerializeField] GameObject scoreText;

    [SerializeField] Text training;
    [SerializeField] string[] t;

    TypeControl currentTypeControl;
    List<TypeControl> typeControls;
    Collider2D collider2D;

    [SerializeField] float timer;
    public float time;

    private void Start()
    {
        time = timer;
        currentTypeControl = TypeControl.jump;
        typeControls = new List<TypeControl>();

        typeControls.Add(TypeControl.jump);
        typeControls.Add(TypeControl.flight);
        typeControls.Add(TypeControl.rail);

        collider2D = player.transform.GetChild(0).GetComponent<Collider2D>();

        PlayerPrefs.DeleteKey("Training");

        if (PlayerPrefs.HasKey("Training"))
        {
            training.gameObject.SetActive(false);
            StartCoroutine(Shift());
        }
        else
        {
            StartCoroutine(Training());
        }
    }

    private void Update()
    {
        if(ObstacleGenerate.generate)
        {
            if(time > 0f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                ObstacleGenerate.generate = false;
                collider2D.enabled = false;
                time = timer;
                StartCoroutine(Shift());
            }
        }
    }

    IEnumerator Shift()
    {
        scoreText.SetActive(false);

        List<TypeControl> newTypeControls = new List<TypeControl>();
        newTypeControls.AddRange(typeControls);
        newTypeControls.Remove(currentTypeControl);

        currentTypeControl = newTypeControls[Random.Range(0, newTypeControls.Count)];
        StartCoroutine(skins.ShiftSkin(currentTypeControl));

        if(shiftMusic.audioSource.volume > 0f)
        {
            StartCoroutine(shiftMusic.ShiftMusic((int)currentTypeControl));
        }

        alertText.gameObject.SetActive(true);
        alertText.text = "1";
        yield return new WaitForSeconds(1f);

        alertText.text = "2";
        yield return new WaitForSeconds(1f);

        alertText.text = "3";
        yield return new WaitForSeconds(1f);
        alertText.gameObject.SetActive(false);

        ActivationController(currentTypeControl);

        ObstacleGenerate.generate = true;
        StartCoroutine(obs.Generate(currentTypeControl));

        scoreText.SetActive(true);
    }

    void ActivationController(TypeControl typeControl)
    {
        jumpPlayer.enabled = false;
        flightPlayer.enabled = false;
        railPlayer.enabled = false;

        collider2D.enabled = true;

        switch (typeControl)
        {
            case TypeControl.flight:
                player.GetComponent<Animator>().enabled = false;
                flightPlayer.enabled = true;
                break;
            case TypeControl.jump:
                player.GetComponent<Animator>().enabled = true;
                jumpPlayer.enabled = true;
                break;
            case TypeControl.rail:
                player.GetComponent<Animator>().enabled = false;
                railPlayer.enabled = true;
                break;
        }
    }

    IEnumerator Training()
    {
        for(int i = 0; i<3; i++)
        {
            training.text = t[i];
            StartCoroutine(skins.ShiftSkin((TypeControl)i));
            ActivationController((TypeControl)i);
            yield return new WaitForSeconds(3f);
        }

        training.text = t[3];
        yield return new WaitForSeconds(3f);
        PlayerPrefs.SetString("Training", "complete");
        training.gameObject.SetActive(false);
        StartCoroutine(Shift());
    }
}

public enum TypeControl {jump, rail, flight}