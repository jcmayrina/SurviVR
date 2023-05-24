using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipItem : Equipable
{
    PlayerMovement player;
    private TextMeshProUGUI promptText;
    void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update() {
        if(player.itemName != null)
        promptText = player.itemName.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if(promptText != null)
        promptText.SetText("take "+player.itemName.name);

    }
    protected override void Equip(){
        Debug.Log(gameObject.name);
        gameObject.SetActive(false);
    }
}
