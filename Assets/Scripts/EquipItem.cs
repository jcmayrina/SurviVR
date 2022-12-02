using UnityEngine;
using System.Collections;

public class EquipItem : Equipable
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Equip(){
        Debug.Log("equipped");
        gameObject.SetActive(false);
    }
}
