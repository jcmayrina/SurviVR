using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescuer : MonoBehaviour
{
    // Start is called before the first frame update
    float crouchtimer;
    int mycrouchtimer;
    PlayerMovement player;
    public GameObject Player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        crouchtimer += 1 * Time.deltaTime;
        mycrouchtimer = (int) crouchtimer;
        if(mycrouchtimer == 16){
            Player.GetComponent<Rigidbody>().isKinematic = false;
            Player.GetComponent<CharacterController>().enabled = true;
        }
        else if(mycrouchtimer == 4){
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if(mycrouchtimer < 16){
            Player.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<CharacterController>().enabled = false;
        }
    }
}
