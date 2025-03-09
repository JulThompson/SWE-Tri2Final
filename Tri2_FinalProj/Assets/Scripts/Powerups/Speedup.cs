using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : Powerup
{
    private int xcoord;
    private int ycoord;
    private int zcoord;
    private GameObject powerupPrefab;

    public Speedup(int x, int y, int z)
    {
        this.xcoord = x;
        this.ycoord = y;
        this.zcoord = z;
        this.powerupPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Speed increaser.prefab");
        GameObject.Instantiate(powerupPrefab, new Vector3(xcoord, ycoord, zcoord), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
