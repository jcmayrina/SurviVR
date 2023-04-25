using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Television : MonoBehaviour
{
    public string promptMessage;

    public void TelevisionPass() {
        TelevisionSwitch();
    }

    protected virtual void TelevisionSwitch() {
    }
}
