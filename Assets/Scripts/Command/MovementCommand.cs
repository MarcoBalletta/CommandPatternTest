using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCommand : Command
{
    public override void Execute(PlayerController player, InputAction.CallbackContext context)
    {
        player.MovementContext = context;
        if (!player.RecAbility.IsRecording) return;

        if(context.ReadValue<float>() > 0)
        {
            player.RecAbility.AddCommand(CommandType.moveRight, player.RecAbility.RecordingTime);
        }
        else if(context.ReadValue<float>() < 0)
        {
            player.RecAbility.AddCommand(CommandType.moveLeft, player.RecAbility.RecordingTime);
        }
        else
        {
            player.RecAbility.AddCommand(CommandType.idle, player.RecAbility.RecordingTime);
        }
    }
}
