using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpCommand : Command
{

    public void Execute(BaseCharacter player)
    {
        player.Rb.AddForce(player.JumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
