using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementLeftCommand : Command
{
    public override void Execute(PlayerController player, InputAction.CallbackContext context)
    {
        if(context.ReadValue<Vector2>().x > 0)
        {

        }
    }
}

public enum Directions
{
    right,
    left,
}
