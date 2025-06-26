using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerInput playerInput;

    private InputAction fireAction;
    private bool canFire = true;
    [SerializeField] private float fireCooldown = 2f;

#region Actions

    private void OnEnable()
    {
        fireAction = playerInput.actions["Fire"];

        fireAction.performed += OnFireStarted;
    }

    private void OnDisable()
    {
        fireAction.performed -= OnFireStarted;
    }

    private void OnFireStarted(InputAction.CallbackContext ctx)
    {
        if (canFire)
        {
            Fire();
        }
    }

    private void OnFireCanceled(InputAction.CallbackContext ctx)
    {
        canFire = false;
    }

#endregion

    private void Fire()
    {
        Debug.Log("FIRE!");
        canFire = false;
        StartCoroutine(FireCooldownCoroutine());
    }

    private IEnumerator FireCooldownCoroutine()
    {
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
        // Debug.Log("Ready to fire again.");
    }

}
