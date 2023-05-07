using UnityEngine;
using System.Collections;

public class GOBag : Equipable
{
    void Start() {

    }
    void Update() {

    }
    protected override void Equip(){
        Debug.Log("equipped");
        gameObject.SetActive(false);
    }
}
