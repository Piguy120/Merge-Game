using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;
    [SerializeField] private bool isGamepad;
    private Vector2 aim;
    public Player_Movement playerMovement;
    [SerializeField] private PlayerInput playerInput;

    private InputAction lookAction;

    private void Awake()
    {
        // Retrieve the "Look" action from the "Player" action map
        lookAction = playerInput.actions["Look"];
        if (playerInput.currentControlScheme == "Gamepad")
        {
            isGamepad = true;
            Debug.Log("Gamepad detected");
        }
        else
        {
            isGamepad = false;
            Debug.Log("Keyboard/Mouse detected");
        }
    }

    private void OnEnable()
    {
        playerMovement.enabled = true;
        lookAction.Enable(); // Enable the "Look" action
    }

    private void OnDisable()
    {
        playerMovement.enabled = false;
        lookAction.Disable(); // Disable the "Look" action
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        aim = lookAction.ReadValue<Vector2>(); // Read the "Look" action value
        if (aim.magnitude > controllerDeadzone)
        {
            // Handle rotation logic here (e.g., rotate the weapon based on aim)
            Debug.Log($"Aim direction: {aim}");
        }
    }
    public void OnDeviceChange(PlayerInput pi)
    {
        if (pi.currentControlScheme == "Gamepad")
        {
            isGamepad = true;
        }
        else
        {
            isGamepad = false;
        }
    }
}
