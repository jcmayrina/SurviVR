using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void HideDoorPass() {
        HideDoor();
    }

    protected virtual void HideDoor() {

    }
}
