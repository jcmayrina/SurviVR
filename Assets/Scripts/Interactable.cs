using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    string itemName;

    public void HideDoorPass() {
        HideDoor();
    }

    public string ClickItem() {
        return name;
    }

    protected virtual void HideDoor() {

    }

    protected virtual string ChooseItem() {
        return name;
    }
}