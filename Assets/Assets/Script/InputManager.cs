using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public event Action OnPlayerShoot;

    private PlayerInputActions playerInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        playerInput = new PlayerInputActions();
        playerInput.Player.Enable();
    }

    private void Start()
    {
        playerInput.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerShoot?.Invoke();
    }

    public float GetRotationAxis()
    {
        return playerInput.Player.TurretRotate.ReadValue<float>();
    }
}
