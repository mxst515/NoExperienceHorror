using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject Panel_MainMenu;
    [SerializeField] GameObject Panel_SettingsMenu;

    [SerializeField] SetupGameScript setupgame;

    public void OnPlayButton(){
        setupgame.StartCoroutine(setupgame.LoadGameScene());
    }

    public void OnQuitButton(){
        Application.Quit();
    }

    public void OnSettingsButton(){
        Panel_SettingsMenu.SetActive(true);
        Panel_MainMenu.SetActive(false);
    }

}
