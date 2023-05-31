using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimePlayed : MonoBehaviour
{
    PlayerMovement player;
    private TextMeshProUGUI time;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
