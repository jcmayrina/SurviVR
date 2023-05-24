using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class InfoTexts : MonoBehaviour
{
    public GameObject rotateText;
    float timer;
    int mytimer;
    private bool enterOnce=false;
    private bool stayOnce=false;
    private bool exitOnce=false;
    public GameObject Player;
    private Transform head;
    private TextMeshProUGUI textWatch;
    private Animator myAnimController;
    public String OnEnter="";
    public String OnStay="";
    public String OnExit="";
    public int timeEnter;
    public int timeStay;
    public int timeExit;
    public bool freezeEnter;
    public bool freezeStay;
    public bool freezeExit;
    
    void Start()
    {
        rotateText.SetActive(false);
        head = Player.transform;
        textWatch = rotateText.GetComponentInChildren<TextMeshProUGUI>();
        myAnimController = rotateText.GetComponent<Animator>();
        textWatch.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        mytimer = (int) timer;
        //Debug.Log(mytimer);
        rotateText.transform.LookAt(new Vector3(head.position.x, rotateText.transform.position.y, head.position.z));
        rotateText.transform.forward *= -1;
        rotateText.transform.Rotate(0, 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnStay=="" && OnEnter!="")
        if(!enterOnce){
        rotateText.SetActive(true);
        textWatch.SetText(OnEnter);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeEnter);
        enterOnce = true;
    
        if (freezeEnter==true)
        {
            TurnOffControls();
            StartCoroutine(waiter());
        }
        }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnEnter=="" && OnStay!= "")
        if(!stayOnce){
        rotateText.SetActive(true);
        textWatch.SetText(OnStay);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeStay);
        stayOnce = true;
        if (freezeStay==true)
        {
            TurnOffControls();
            StartCoroutine(waiter());
        }
        }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnExit!="")
        if(!exitOnce){
        rotateText.SetActive(true);
        textWatch.SetText(OnExit);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeExit);
        exitOnce = true;
        if (freezeExit==true)
        {
            TurnOffControls();
            StartCoroutine(waiter());
        }
        }
        }
    }
    void HideText(){
            myAnimController.SetBool("showText",false);
    }
    
    public void TurnOffControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
        Player.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    }

    public void TurnOnControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
        Player.gameObject.GetComponent<Rigidbody>().isKinematic=false;
    }
    
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
        TurnOnControls();
    }
}