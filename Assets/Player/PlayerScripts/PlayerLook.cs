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
    }
}
