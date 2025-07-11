using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraTransform;

    [Header("Components")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Settings")]
    public float mouseSensitivity = 2f;
    public float verticalClamp = 80f;
    public float mouseSensitivityNormalization = 0.1f;

    private float xRotation = 0f;
    // private PlayerInput playerInput;
    private InputAction lookAction;

    [Header("Headbob Settings")]
    public bool enableHeadbob = true;
    public float headbobSpeed = 14f;
    public float headbobAmount = 0.05f;
    public float headbobSmoothSpeed = 10f;
    [SerializeField] private PlayerMovementScriptGeneral playerMovement;

    private Vector3 originalCameraPosition;
    private float headbobTimer = 0f;

    private void Awake()
    {
        // playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        lookAction = playerInput.actions["Look"];
    }

    private void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * mouseSensitivityNormalization;
        float mouseY = lookInput.y * mouseSensitivity * mouseSensitivityNormalization;

        // Obrót ciała gracza (lewo/prawo)
        transform.Rotate(Vector3.up * mouseX);

        // Obrót kamery (góra/dół)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        HandleHeadbob();

    }

    private void HandleHeadbob()
    {
        if (!enableHeadbob || !playerMovement.isGrounded) 
        {
            // Resetuj pozycję, jeśli headbob wyłączony lub w powietrzu
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalCameraPosition, Time.deltaTime * headbobSmoothSpeed);
            return;
        }

        float speed = playerMovement.currentHorizontalVelocity.magnitude;
        if (speed < 0.1f)
        {
            // Resetuj gdy nie ma ruchu
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalCameraPosition, Time.deltaTime * headbobSmoothSpeed);
            return;
        }

        headbobTimer += Time.deltaTime * headbobSpeed * (speed / playerMovement.walkSpeed);

        float bobX = Mathf.Cos(headbobTimer) * headbobAmount * 0.1f;
        float bobY = Mathf.Abs(Mathf.Sin(headbobTimer)) * headbobAmount * 0.8f;

        Vector3 targetPosition = originalCameraPosition + new Vector3(bobX, bobY, 0f);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, targetPosition, Time.deltaTime * headbobSmoothSpeed);
    }
}
