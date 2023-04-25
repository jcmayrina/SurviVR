using UnityEngine;


public class TVfreeze : MonoBehaviour
{
    float crouchtimer;
    int mycrouchtimer;
    public CharacterController rigidbodyfreeze;
    // Start is called before the first frame update
    void Start()
    {
            TurnOffControls();
    }
    // Update is called once per frame
    void Update()
    {
        crouchtimer += 1 * Time.deltaTime;
        mycrouchtimer = (int) crouchtimer;
        if(mycrouchtimer > 64){
            TurnOnControls();
        }
    }
    public void TurnOffControls()
    {
        rigidbodyfreeze.enabled = false;
    }

    public void TurnOnControls()
    {
        rigidbodyfreeze.enabled = true;
    }
}
