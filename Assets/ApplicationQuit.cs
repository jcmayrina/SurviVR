using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    float crouchtimer;
    int mycrouchtimer;

    void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            crouchtimer += 1 * Time.deltaTime;
            mycrouchtimer = (int) crouchtimer;
            if(mycrouchtimer == 2)
                Application.Quit();
        }
    }
}
