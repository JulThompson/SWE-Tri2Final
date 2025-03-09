using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStateNormal : PlayerState
{
    private PlayerController player;
    private Rigidbody2D rb;
    private GameObject projectilePrefab;
    private GameObject speedPrefab;

    public PlayerStateNormal(PlayerController player, Rigidbody2D rb, GameObject prefab, GameObject sprefab)
    {
        this.player = player;
        this.rb = rb;
        this.projectilePrefab = prefab;
        this.speedPrefab = sprefab;
    }

    public void handleSpace()
    {
        Debug.Log("hit");
        // Create a projectile
        GameObject.Instantiate(projectilePrefab, new Vector3(player.transform.position.x, player.transform.position.y + 1, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        
        // Begin cooldown
        player.setState(new PlayerStateFiring(player, rb, 100, projectilePrefab, speedPrefab, this));
    }

    public void advanceState()
    {
    }

}