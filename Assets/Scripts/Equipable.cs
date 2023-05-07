using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : MonoBehaviour
{
    public string promptMessage;
    public string ObjectName;

    public void EquipPass() {
        Equip();
    }

    protected virtual void Equip() {

    }
}
