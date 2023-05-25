using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : Interactable
{
    // public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override string ChooseItem() {
        gameObject.GetComponent<AudioSource>().Play();
        return gameObject.name;
    }
}
