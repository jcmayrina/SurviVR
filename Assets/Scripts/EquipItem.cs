using UnityEngine;
using System.Collections;

public class EquipItem : Equipable
{
    void Start() {

    }
    void Update() {

    }
    protected override void Equip(){
        Debug.Log(gameObject.name);
        gameObject.SetActive(false);
    }
}
