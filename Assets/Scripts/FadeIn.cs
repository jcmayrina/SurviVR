using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame updates
    float timer;
    int mytimer;
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        mytimer = (int) timer;
        if(mytimer == 3){
            Player.GetComponent<Rigidbody>().isKinematic = false;
            Player.GetComponent<CharacterController>().enabled = true;
            gameObject.SetActive(false);;
        }
        else if (mytimer < 3){
            Player.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<CharacterController>().enabled = false;
        }
    }
}
