using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tent : Equipable
{
    PlayerMovement player;
    private TextMeshProUGUI promptText;
    void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update() {
        if(player.itemName != null){
        promptText = player.itemName.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    protected override void Equip(){
    }
}
