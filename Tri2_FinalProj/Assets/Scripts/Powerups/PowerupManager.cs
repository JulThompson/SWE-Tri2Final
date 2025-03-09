using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public PowerupFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        factory = new PowerupFactory();
    }

    // Update is called once per frame
    void Update()
    {
        int rand = UnityEngine.Random.Range(0, 3000);
        if (rand == 1)
        {
            factory.newPowerup();
        }
    }
}
