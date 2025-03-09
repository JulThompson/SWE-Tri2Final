using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private PlayerState state;

    public ShootCommand(PlayerState state)
    {
        this.state = state;
    }

    public void Execute()
    {
        state.handleSpace();
    }
}
