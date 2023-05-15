using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class InfoTexts : MonoBehaviour
{
    float timer;
    int mytimer;
    private bool enterOnce=false;
    private bool stayOnce=false;
    private bool exitOnce=false;
    public GameObject Player;
    public TextMeshProUGUI textWatch;
    public GameObject bgColor;
    [SerializeField] private Animator myAnimController;
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
        textWatch.SetText("");
        bgColor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        mytimer = (int) timer;
        //Debug.Log(mytimer);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnStay=="")
        if(!enterOnce){
        bgColor.SetActive(true);
        textWatch.SetText(OnEnter);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeEnter);
        enterOnce = true;
        if (freezeEnter==true)
        {
            //TurnOffControls(other);
            StartCoroutine(waiter());
        }
        }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnEnter=="")
        if(!stayOnce){
        bgColor.SetActive(true);
        textWatch.SetText(OnStay);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeStay);
        stayOnce = true;
        if (freezeStay==true)
        {
            //TurnOffControls(other);
            StartCoroutine(waiter());
        }
        }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
        if(!exitOnce){
        bgColor.SetActive(true);
        textWatch.SetText(OnExit);
        myAnimController.SetBool("showText",true);
        Invoke("HideText",timeExit);
        exitOnce = true;
        if (freezeExit==true)
        {
            //TurnOffControls(other);
            StartCoroutine(waiter());
        }
        }
        }
    }
    void HideText(){
            myAnimController.SetBool("showText",false);
    }
    
    public void TurnOffControls(Collider collider)
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
    }

    public void TurnOnControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
    }
    
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
    }
}