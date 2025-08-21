using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] PlayerMovementScriptGeneral playerMovementScript;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)){
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

        if(!InspectNoteScript.anyNoteOpen){
            playerLook.enabled = true;
            playerMovementScript.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameIsPaused = false;

        // Cursor.visible = false;

    }

    public void Pause(){
        pauseUI.SetActive(true);
        playerLook.enabled = false;
        playerMovementScript.enabled = false;

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
