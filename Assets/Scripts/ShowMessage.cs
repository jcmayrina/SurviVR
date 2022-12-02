using UnityEngine;
using System.Collections;

public class ShowMessage : Interactable
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact(){
        Debug.Log("HELLO");
    }
}
