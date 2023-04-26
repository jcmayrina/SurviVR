using UnityEngine;
using System.Collections;

public class OpenDoor : Interactable
{
    public MeshRenderer gameobj;
    public MeshRenderer gameobj2;
    public BoxCollider boxcollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void HideDoor(){
        Debug.Log("open door");
        gameobj.enabled=false;
        gameobj2.enabled=false;
        boxcollider.enabled=false;
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(4);
        gameobj.enabled=true;
        gameobj2.enabled=true;
        boxcollider.enabled=true;
    }
}
