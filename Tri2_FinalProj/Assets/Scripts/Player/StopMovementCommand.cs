using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovementCommand : ICommand
{
    private PlayerController player;

    public StopMovementCommand(PlayerController player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.rb.velocity = Vector2.zero;
    }
}
