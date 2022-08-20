using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Command
{
    public virtual void Execute(PlayerController player, InputAction.CallbackContext context) { }
}

[System.Serializable]
public enum CommandType
{
    moveLeft,
    moveRight,
    idle,
    jump,
}
