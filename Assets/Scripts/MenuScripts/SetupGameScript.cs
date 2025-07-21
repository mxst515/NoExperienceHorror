using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupGameScript : MonoBehaviour
{
    [SerializeField] GameObject Panel_MainMenu;
    [SerializeField] GameObject Panel_SettingsMenu;

    [SerializeField] private GameObject loadingScreen;

    void Start()
    {
        Panel_MainMenu.SetActive(true);
        Panel_SettingsMenu.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public IEnumerator LoadGameScene(){
        Panel_MainMenu.SetActive(false);
        loadingScreen.SetActive(true);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        asyncLoad.allowSceneActivation = false;

        //Wait till scene is 90% loaded
        while (asyncLoad.progress < 0.9f){
            yield return null;
        }

        //Short Pause (optional) 
        yield return new WaitForSeconds(0.2f);

        //Activate Scene
        asyncLoad.allowSceneActivation = true;
    }

}
