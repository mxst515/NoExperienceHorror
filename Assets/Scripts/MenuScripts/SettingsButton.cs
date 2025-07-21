using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject Panel_MainMenu;
    [SerializeField] GameObject Panel_SettingsMenu;

    public void OnClickBackSettings(){
        Panel_SettingsMenu.SetActive(false);
        Panel_MainMenu.SetActive(true);
    }

}
