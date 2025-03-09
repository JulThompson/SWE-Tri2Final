using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private PlayerController player;

    public MoveLeftCommand(PlayerController player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.rb.velocity = new Vector2(-player.velocity, 0);
    }
}
