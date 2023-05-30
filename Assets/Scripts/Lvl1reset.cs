
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1reset : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        player.objectiveLists.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
