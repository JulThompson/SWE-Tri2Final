using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    private PlayerController player;

    public MoveRightCommand(PlayerController player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.rb.velocity = new Vector2(player.velocity, 0);
    }
}