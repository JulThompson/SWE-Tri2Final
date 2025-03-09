using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireup : Powerup
{
    private int xcoord;
    private int ycoord;
    private int zcoord;
    private GameObject powerupPrefab;

    public Fireup(int x, int y, int z)
    {
        this.xcoord = x;
        this.ycoord = y;
        this.zcoord = z;
        this.powerupPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/firerate increaser.prefab");
        GameObject.Instantiate(powerupPrefab, new Vector3(xcoord, ycoord, zcoord), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
