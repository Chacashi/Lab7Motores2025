using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnPlayerMovement;
    public static event Action<bool> OnPressedE;
    PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        PatrolController.OnEnemySpeaking += ManipulateInput;
        PatrolController.OnEnemyFinishSpeaking += ManipulateInput;
    }

    private void OnDisable()
    {
        PatrolController.OnEnemySpeaking -= ManipulateInput;
        PatrolController.OnEnemyFinishSpeaking -= ManipulateInput;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovement?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteractue(InputAction.CallbackContext context)
    {
        OnPressedE.Invoke(context.performed);
    }


    void ManipulateInput()
    {
        if (playerInput.inputIsActive)
        {
            playerInput.DeactivateInput();
        }
        else
        {
            playerInput.ActivateInput();
        }
    }
}
