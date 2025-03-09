using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup
{
    private int xcoord;
    private int ycoord;
    private int zcoord;
    private GameObject powerupPrefab;

    public Powerup()
    {
    }

    public Powerup(int x, int y, int z)
    {
        this.xcoord = x;
        this.ycoord = y;
        this.zcoord = z;
    }
}
