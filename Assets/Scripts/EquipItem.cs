using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipItem : Equipable
{
    Equipable equipable;
    PlayerMovement player;
    private TextMeshProUGUI promptText;
    void Start() {
        equipable = FindObjectOfType<Equipable>();
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update() {
        Debug.Log(player.itemName);
        if(player.itemName != null)
        promptText = player.itemName.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(promptText);
        if(promptText != null)
        UpdateText(equipable.promptMessage);

    }
    protected override void Equip(){
        Debug.Log(gameObject.name);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void UpdateText(string promptMessage) {
        promptText.SetText(promptMessage);
    }
}
