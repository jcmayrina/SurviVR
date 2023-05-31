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
        if(player.itemName != null){
        promptText = player.itemName.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if(promptText != null){
            if(player.pickDustpan == false && player.pickBroom == false && player.itemName.name == "shrub"){
                promptText.SetText("Pick up dustpan and broom first!");
            }
            else if(player.pickBroom == false && player.itemName.name == "shrub"){
                promptText.SetText("pick up broom first!");
            }
            else if(player.pickDustpan == false && player.itemName.name == "shrub"){
                promptText.SetText("pick up dustpan first!");
            }
            else
            {
                promptText.SetText("take "+player.itemName.name);
            }
        gameObject.transform.Find("Canvas").transform.LookAt(new Vector3(player.transform.position.x, gameObject.transform.Find("Canvas").transform.position.y, player.transform.position.z));
        gameObject.transform.Find("Canvas").transform.forward *= -1;
        gameObject.transform.Find("Canvas").transform.Rotate(30, 0, 0);
        }
        }
    }
    protected override void Equip(){
        if(player.pickDustpan == false && player.pickBroom == false && player.itemName.name == "shrub"){
            Debug.Log("pick up dustpan and broom first!");
        }
        else if(player.pickBroom == false && player.itemName.name == "shrub"){
            Debug.Log("pick up broom first!");
        }
        else if(player.pickDustpan == false && player.itemName.name == "shrub"){
            Debug.Log("pick up dustpan first!");
        }
        else{
        player.objectiveLists.Add(gameObject.name);
        Debug.Log("added "+gameObject.name);
        gameObject.SetActive(false);
        player.click.Play();
        }
    }
}
