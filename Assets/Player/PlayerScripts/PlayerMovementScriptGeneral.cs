using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovementScriptGeneral : MonoBehaviour
{
    [Header("Crouch Settings")]
    public float standScale = 1f;
    public float crouchScale = 0.8f;

    [Header("Movement Settings")]
    public float walkSpeed = 4f; //4f; 
    public float sprintSpeed = 6f; //7f;
    public float crouchSpeed = 2f;
    public float crouchSprintSpeed = 3.5f;
    public float jumpHeight = 1f; //1.2f;
    public float gravity = -10f; //-9.81f;

    [Header("Movement Smoothing")]
    [Tooltip("Jak szybko gracz osiąga docelową prędkość na ziemi.")]
    public float groundAcceleration = 8f; //10f;
    [Tooltip("Jak szybko gracz zwalnia do zera na ziemi, gdy nie ma inputu.")]
    public float groundDeceleration = 20f;
    [Tooltip("Jak dużą kontrolę nad prędkością poziomą ma gracz w powietrzu.")]
    public float airAcceleration = 3f; //5f;
    [Tooltip("Jak szybko gracz traci prędkość poziomą w powietrzu, gdy nie ma inputu (symuluje opór powietrza).")]
    public float airDeceleration = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Movement Components")]
    [SerializeField] private CharacterController controller;
    private Vector2 movementInput;
    private Vector3 verticalVelocity; // Przechowuje tylko prędkość pionową (grawitacja, skok)
    private Vector3 currentHorizontalVelocity; // Przechowuje aktualną prędkość poziomą gracza

    [Header("Input Actions Components")]
    [SerializeField] private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction runAction;
    private InputAction crouchAction;

    [Header("Debug booleans")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool isCrouching = false;

    private void Awake()
    {
        // controller = GetComponent<CharacterController>();
        // playerInput = GetComponent<PlayerInput>();
        currentHorizontalVelocity = Vector3.zero;   // Inicjalizacja prędkości poziomej <-/->
        verticalVelocity = Vector3.zero;            // Inicjalizacja prędkości pionowej ^/v
    }

    private void OnEnable()
    {
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        runAction = playerInput.actions["Run"];
        crouchAction = playerInput.actions["Crouch"];

        jumpAction.performed += ctx => Jump();

        runAction.performed += ctx => isRunning = true;
        runAction.canceled += ctx => isRunning = false;

        crouchAction.performed += ctx => {isCrouching = true; Crouch(); };
        crouchAction.canceled += ctx => {isCrouching = false; Crouch(); };
    }

    private void OnDisable()
    {
        jumpAction.performed -= ctx => Jump();

        runAction.performed -= ctx => isRunning = true;
        runAction.canceled -= ctx => isRunning = false;

        crouchAction.performed -= ctx => {isCrouching = true; Crouch(); };
        crouchAction.canceled -= ctx => {isCrouching = false; Crouch(); };
    }

    void Update()
    {
        HandleInput(); // Pobierz input

        // Sprawdź, czy gracz jest na ziemi - raz na klatkę
        
        HandleGroundStatus();           // Zarządzaj statusem na ziemi (np. reset prędkości pionowej)
        HandleHorizontalMovement();     // Oblicz i zaktualizuj prędkość poziomą
        HandleVerticalMovement();       // Oblicz i zaktualizuj prędkość pionową (grawitacja)

        // Połącz prędkość poziomą i pionową, a następnie wykonaj ruch
        MovePlayer();
        
    }

    void HandleInput()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void HandleGroundStatus()
    {
        // Sprawdź, czy gracz jest na ziemi
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalVelocity.y < 0)
        {
            // Mała siła w dół, aby gracz "przykleił się" do podłoża
            // Zapobiega to podskakiwaniu na nierównościach
            verticalVelocity.y = -2f;
        }
    }

    void HandleHorizontalMovement()
    {
        // Określ docelową prędkość na podstawie tego, czy gracz biegnie czy idzie
        // float targetSpeed = isRunning ? sprintSpeed : walkSpeed;
        float targetSpeed;

        if (isCrouching && isRunning){
            targetSpeed = crouchSprintSpeed;
        }
        else if(isCrouching){
            targetSpeed = crouchSpeed;
        }
        else if (isRunning){
            targetSpeed = sprintSpeed;
        }
        else{
            targetSpeed = walkSpeed;
        }

        // Oblicz wektor docelowej prędkości na podstawie inputu i orientacji gracza
        Vector3 targetHorizontalVelocity;
        float effectiveLerpSpeed;

        if (movementInput.sqrMagnitude > 0.01f) // Jeśli jest znaczący input
        {
            // Kierunek ruchu na podstawie inputu i orientacji kamery/gracza
            Vector3 moveDirection = (transform.right * movementInput.x + transform.forward * movementInput.y).normalized;
            targetHorizontalVelocity = moveDirection * targetSpeed;

            // Użyj współczynnika przyspieszenia odpowiedniego dla stanu (na ziemi / w powietrzu)
            effectiveLerpSpeed = isGrounded ? groundAcceleration : airAcceleration;
        }
        else // Jeśli nie ma inputu, gracz powinien zwolnić
        {
            targetHorizontalVelocity = Vector3.zero; // Docelowa prędkość to zero

            // Użyj współczynnika zwalniania odpowiedniego dla stanu
            effectiveLerpSpeed = isGrounded ? groundDeceleration : airDeceleration;
        }

        // Płynnie interpoluj aktualną prędkość poziomą w kierunku docelowej prędkości
        currentHorizontalVelocity = Vector3.Lerp(currentHorizontalVelocity, targetHorizontalVelocity, effectiveLerpSpeed * Time.deltaTime);

        // Debug.Log("tagetHorizontalVelocity: " + targetHorizontalVelocity);    // debug
        // Debug.Log("effectiveLerpSpeed: " + effectiveLerpSpeed);               // debug
        // Debug.Log("currentHorizontalVelocity: " + currentHorizontalVelocity); // debug

    }

    void HandleVerticalMovement() // Poprzednio HandleGravity
    {
        // Grawitacja jest stosowana ciągle, chyba że gracz jest na ziemi i nie spada
        // (co jest obsługiwane w HandleGroundStatus)
        verticalVelocity.y += gravity * Time.deltaTime;
    }

    void Jump()
    {
        if (!isGrounded) return; // Skacz tylko jeśli jesteś na ziemi

        // Ustaw prędkość pionową, aby osiągnąć żądaną wysokość skoku
        // Prędkość pozioma (currentHorizontalVelocity) zostanie zachowana
        verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            transform.localScale = Vector3.one;
        }
        else
            transform.localScale = new Vector3(1, crouchScale, 1);
    }

    void MovePlayer(){
        Vector3 finalVelocity = currentHorizontalVelocity + verticalVelocity;
        controller.Move(finalVelocity * Time.deltaTime);

        // Debug.Log("finalVelocity: " + finalVelocity); // debug
    }

    
}