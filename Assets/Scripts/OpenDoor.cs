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
        if (gameObject.tag =="TopCabinetL")
        anim.Play("LTopcabinetOpen");
        if (gameObject.tag =="TopCabinetR")
        anim.Play("RTopcabinetOpen");
        StartCoroutine(waiter());
        if (gameObject.tag =="CabinetL")
        anim.Play("LcabinetOpen");
        if (gameObject.tag =="CabinetR")
        anim.Play("RcabinetOpen");
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(10);
        gameObject.GetComponent<BoxCollider>().enabled=true;
        if (gameObject.tag =="Door")
        anim.Play("doorClose");
        if (gameObject.tag =="Ref")
        anim.Play("refClose");
        if (gameObject.tag =="TopCabinetL")
        anim.Play("LTopcabinetClose");
        if (gameObject.tag =="TopCabinetR")
        anim.Play("RTopcabinetClose");
        if (gameObject.tag =="CabinetL")
        anim.Play("LcabinetClose");
        if (gameObject.tag =="CabinetR")
        anim.Play("RcabinetClose");
    }
}
