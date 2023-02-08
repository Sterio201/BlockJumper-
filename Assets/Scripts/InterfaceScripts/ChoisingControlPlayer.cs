using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoisingControlPlayer : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Controller"))
        {
            dropdown.value = PlayerPrefs.GetInt("Controller");
        }
    }

    public void ShiftControl()
    {
        PlayerPrefs.SetInt("Controller", dropdown.value);
    }
}