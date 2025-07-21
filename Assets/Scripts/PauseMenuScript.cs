using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private PlayerLook playerLook;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Awake()
    {
        GameIsPaused = false;
        pauseUI.SetActive(false);
    }

    public void Resume(){
        pauseUI.SetActive(false);
        playerLook.enabled = true;

        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    public void Pause(){
        pauseUI.SetActive(true);
        playerLook.enabled = false;

        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }

    public void OnBackMenuButton(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnResume(){
        Resume();
    }
}
