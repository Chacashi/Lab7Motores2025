using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> OnPlayerMovement;
     public void OnMovement(InputAction.CallbackContext context)
    {
        OnPlayerMovement?.Invoke(context.ReadValue<Vector2>());
    }

}
