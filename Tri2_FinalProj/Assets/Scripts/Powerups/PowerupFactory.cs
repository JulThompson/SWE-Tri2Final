using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFactory
{

    public PowerupFactory()
    {
    }

    public Powerup newPowerup()
    {
        int rand = UnityEngine.Random.Range(0, 2);
        int randx = UnityEngine.Random.Range(-12, 12);
        int y = 5;
        int z = -1;
        Powerup p;

        if (rand == 1)
        {
            p = new Fireup(randx, y, z);
        }
        else
        {
            p = new Speedup(randx, y, z);
        }

        return p;
    }
}
