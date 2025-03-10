using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerStateSpeedup : PlayerState
{
    private PlayerController player;
    private Rigidbody2D rb;
    private GameObject projectilePrefab;
    private GameObject speedPrefab;

    private int cooldown;

    public PlayerStateSpeedup(PlayerController player, Rigidbody2D rb, GameObject prefab, GameObject sprefab, int c)
    {
        this.player = player;
        this.rb = rb;
        this.projectilePrefab = prefab;
        this.speedPrefab = sprefab;
        this.cooldown = c;

        // increases velocity
        player.changeVelocity();
    }

    public void handleSpace()
    {
        UnityEngine.Debug.Log("hit");
        // Create a projectile
        GameObject.Instantiate(projectilePrefab, new Vector3(player.transform.position.x, player.transform.position.y + 1, 0), Quaternion.Euler(new Vector3(0, 0, 90)));

        // Begin cooldown
        player.setState(new PlayerStateFiring(player, rb, 100, projectilePrefab, speedPrefab, this));
    }

    public void advanceState()
    {
        cooldown--;
        if (cooldown <= 0)
        {
            player.changeVelocity();
            player.setState(new PlayerStateNormal(player, rb, projectilePrefab, speedPrefab));
        }
    }

}