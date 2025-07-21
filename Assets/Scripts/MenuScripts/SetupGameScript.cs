using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGameScript : MonoBehaviour
{
    [SerializeField] GameObject Panel_MainMenu;
    [SerializeField] GameObject Panel_SettingsMenu;

    void Start()
    {
        Panel_MainMenu.SetActive(true);
        Panel_SettingsMenu.SetActive(false);
    }

}
