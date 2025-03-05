using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStateNormal : PlayerState
{
    private PlayerController player;
    private Rigidbody2D rb;

    public PlayerStateNormal(PlayerController player, Rigidbody2D rb)
    {
        this.player = player;
        this.rb = rb;
    }

    public void handleSpace()
    {
        //player.setState(new PlayerStateFiring(player, 10));
    }

    public void handleCollision()
    {
        //TODO
    }

    public void advanceState()
    {
        //TODO
    }

}