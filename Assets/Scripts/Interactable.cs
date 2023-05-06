using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    string itemName;
    private Animation anim;

    public void HideDoorPass() {
        HideDoor();
    }
    public void Hover() {
        HoverItem();
    }

    public string ClickItem() {
        return name;
    }

    protected virtual void HideDoor() {

    }

    protected virtual string ChooseItem() {
        return name;
    }
    protected virtual void HoverItem() {
        
    }
}
