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
    protected override void HideDoor(){
        Debug.Log("removed");
        gameObject.SetActive(false);
    }
}
