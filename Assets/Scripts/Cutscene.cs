using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject anim;
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            anim.GetComponent<Animation>().Play("equipBroom");
        }
    }
}
