using UnityEngine;
using System.Collections;

public class OpenDoor : Interactable
{
    public BoxCollider boxcollider;
    private Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void HideDoor(){
        Debug.Log("open door");
        boxcollider.enabled=false;
        if (gameObject.tag =="Door")
        anim.Play("doorOpen");
        if (gameObject.tag =="Ref")
        anim.Play("refOpen");
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(4);
        boxcollider.enabled=true;
        if (gameObject.tag =="Door")
        anim.Play("doorClose");
        if (gameObject.tag =="Ref")
        anim.Play("refClose");
    }
}
