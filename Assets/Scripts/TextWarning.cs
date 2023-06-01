using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class TextWarning : MonoBehaviour
{
    public GameObject rotateText;
    public GameObject Player;
    private Transform head;
    private TextMeshProUGUI textWatch;
    private Animator myAnimController;
    public String OnEnter="";
    public String OnStay="";
    public String OnExit="";
    
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
        rotateText.transform.LookAt(new Vector3(head.position.x, rotateText.transform.position.y, head.position.z));
        rotateText.transform.forward *= -1;
        rotateText.transform.Rotate(0, 0, 0);
        rotateText.transform.position = head.position + new Vector3(head.forward.x, .7f, head.forward.z).normalized * 4;
    }
    void OnTriggerEnter(Collider other)
    {
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
        if(OnEnter=="" && OnStay!= ""){
        rotateText.SetActive(true);
        textWatch.SetText(OnStay);
        myAnimController.SetBool("showText",true);
        }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
        HideText();
        }
    }
    void HideText(){
            myAnimController.SetBool("showText",false);
    }
}