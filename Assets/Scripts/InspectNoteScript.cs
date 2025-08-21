using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InspectNoteScript : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInput playerInput;
    private InputAction pressAction;


    [SerializeField] GameObject player;
    [SerializeField] PlayerLook playerLookScript;
    [SerializeField] PlayerMovementScriptGeneral playerMovementScript;

    [SerializeField] GameObject noteUI;
    
    [SerializeField] GameObject pickUpText;

    public static bool anyNoteOpen = false;

    public bool inReach = false;
    public bool noteOpen = false;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        inReach = false;
        noteOpen = false;
        anyNoteOpen = false;
    }

    void OnEnable()
    {
        pressAction = playerInput.actions["Press"];
        pressAction.performed += OnPress;
        pressAction.Enable();
    }

    void OnDisable()
    {
        pressAction.performed -= OnPress;
        pressAction.Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach"){
            // Debug.Log("contact");
            inReach = true;
            if(!noteOpen){
                pickUpText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Reach"){
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void OnPress(InputAction.CallbackContext ctx){
        if(!inReach){
             return;
        }
        else{
            ToggleNote();
        }
    }

    private void ToggleNote(){
        noteOpen = !noteOpen;

        noteUI.SetActive(noteOpen);
        pickUpText.SetActive(!noteOpen);

        playerLookScript.enabled = !noteOpen;
        playerMovementScript.enabled = !noteOpen;

        anyNoteOpen = noteOpen;
    }

    public bool CheckNoteOpen(){
        return noteOpen;
    }
}
