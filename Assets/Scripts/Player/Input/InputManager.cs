using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private InputSystem input;

    private void Awake()
    {
        input = new InputSystem();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movement.Forward.started += Move;
        input.Movement.Forward.canceled += StopMove;
        input.Movement.Jump.started += Jump;
        input.Record.StartRecording.started += Record;
        input.Record.SpawnGhost.started += SpawnGhost;
    }

    private void OnDisable()
    {
        input.Disable();
    }


    public delegate void OnMovement(InputAction.CallbackContext context);
    public OnMovement onMovement;

    public void Move(InputAction.CallbackContext context)
    {
        if (onMovement == null) return;

        onMovement(context);
    }
    
    public delegate void OnStopMovement(InputAction.CallbackContext context);
    public OnStopMovement onStopMovement;

    public void StopMove(InputAction.CallbackContext context)
    {
        if (onStopMovement == null) return;

        onStopMovement(context);
    }

    public delegate void OnStartRecording(InputAction.CallbackContext context);
    public OnStartRecording onStartRecording;

    public void Record(InputAction.CallbackContext context)
    {
        if (onStartRecording == null) return;

        onStartRecording(context);
    }
    
    public delegate void OnJumpStarted(InputAction.CallbackContext context);
    public OnJumpStarted onJumpStarted;
    public void Jump(InputAction.CallbackContext context)
    {
        if (onJumpStarted == null) return;

        onJumpStarted(context);
    }

    public delegate void OnSpawnGhost(InputAction.CallbackContext context);
    public OnSpawnGhost onSpawnGhost;

    public void SpawnGhost(InputAction.CallbackContext context)
    {
        if(onSpawnGhost == null) return;

        onSpawnGhost(context);
    }

    public InputSystem Input { get => input; }

}
