using UnityEngine;
using System.Collections;

public class OpenDoor : Interactable
{
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
        gameObject.GetComponent<BoxCollider>().enabled=false;
        if (gameObject.tag =="Door")
        anim.Play("doorOpen");
        if (gameObject.tag =="Ref")
        anim.Play("refOpen");
        if (gameObject.tag =="CabinetL")
        anim.Play("LcabinetOpen");
        if (gameObject.tag =="CabinetR")
        anim.Play("RcabinetOpen");
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(4);
        gameObject.GetComponent<BoxCollider>().enabled=true;
        if (gameObject.tag =="Door")
        anim.Play("doorClose");
        if (gameObject.tag =="Ref")
        anim.Play("refClose");
        if (gameObject.tag =="CabinetL")
        anim.Play("LcabinetClose");
        if (gameObject.tag =="CabinetR")
        anim.Play("RcabinetClose");
    }
}
