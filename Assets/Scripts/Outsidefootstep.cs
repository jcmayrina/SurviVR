using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outsidefootstep : MonoBehaviour
{
    
    public GameObject Player;
    public AudioClip outfoot;
    // Start is called before the first frame update
    
    void OnTriggerStay(Collider other){
    if(other.CompareTag("Player")){
    Player.GetComponent<AudioSource>().clip = outfoot;
    }
    }
}
