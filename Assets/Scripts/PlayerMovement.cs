
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{   
    public Transform head;
    public GameObject hotbarUI;
    public GameObject MainMenu;
    public GameObject flashlight;
    public String itemChoose="";
    public float speed = 5f;
    private float gravity = 10f;
    Rigidbody myRb;
    private Camera cam;
    private Animation anim;
    private bool flag;
    private bool isAvailable;
    public AudioSource footsteps;
    public AudioSource click;
    public AudioSource whistle;
    private float keyDelay = .2f;
    private float timePassed = 0f;
    public bool canMove;
    public GameObject itemName;
    public int timePlay;
    public List<string> objectiveLists = new List<string>();
    public GameObject objectCheck;
    public bool pickBroom;
    public bool pickDustpan;

    //-----Controller related objects and variables
    private CharacterController controller;
    public PlayerInputActions playerControls;
    private InputAction fire,buttB,buttY,buttX,buttSel,buttSt;
    private InputAction navigate;

    //-----Serialize Fields for Raycast
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private LayerMask mask;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    void Start()
    {
        canMove = true;
        controller = GetComponent<CharacterController>();
        myRb = GetComponent<Rigidbody>();
        flashlight.SetActive(false);
        hotbarUI.SetActive(false);
        MainMenu.SetActive(false);
        cam = Camera.main;
    }
    void Update(){
        timePassed += Time.deltaTime;
        foreach( var x in objectiveLists) {
        //Debug.Log( x.ToString());
        }
        playerMove();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                 if(hitInfo.collider.tag == "Hotbar" && hitInfo.collider.gameObject.transform.GetChild(0).gameObject.activeSelf){
                    hitInfo.collider.GetComponentInChildren<Animation>().Play("InventorySelected");
                }
            }

            else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                //Turn on equipable texts
                hitInfo.collider.transform.GetChild(0).gameObject.SetActive(true);
                itemName = hitInfo.collider.gameObject;
            }


            else if(hitInfo.collider.GetComponent<Television>() != null) {
            }
           
        }
        else{
            //Turn off equipable texts
            if(itemName != null && itemName.transform.GetChild(0).gameObject.activeSelf == true){
                itemName.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        if(head.eulerAngles.x >= 50 && head.eulerAngles.x <= 90) {
            if(Input.GetButton("ButtonA") && timePassed >= keyDelay){
                Debug.Log("buttA inv");

                if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                    if(hitInfo.collider.tag == "inventoryIcon" && !hotbarUI.activeSelf) {
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hotbarUI.SetActive(true);
                        spawnInventory();
                        Debug.Log("Hotbar open");
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory1sfx").GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<CharacterController>().enabled = false;
                    }
                    else {
                        gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        hotbarUI.SetActive(false);
                        Debug.Log("Hotbar close");
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory2sfx").GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<CharacterController>().enabled = true;
                    }
                    if(hitInfo.collider.tag == "MainMenu" && !MainMenu.activeSelf) {
                        MainMenu.SetActive(true);
                        spawnInventory();
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory1sfx").GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<CharacterController>().enabled = false;
                    }
                    else {
                        gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        MainMenu.SetActive(false);
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory2sfx").GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<CharacterController>().enabled = true;
                    }
                }
                timePassed = 0f;
            }

            gameObject.transform.GetChild(3).gameObject.transform.Find("InvImage").GetComponent<RawImage>().enabled = true;
            gameObject.transform.GetChild(3).gameObject.transform.Find("InvImage").GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.GetChild(3).gameObject.transform.Find("ExitImage").GetComponent<RawImage>().enabled = true;
            gameObject.transform.GetChild(3).gameObject.transform.Find("ExitImage").GetComponent<BoxCollider>().enabled = true;
        }
        else {
            gameObject.transform.GetChild(3).gameObject.transform.Find("InvImage").GetComponent<RawImage>().enabled = false;
            gameObject.transform.GetChild(3).gameObject.transform.Find("ExitImage").GetComponent<RawImage>().enabled = false;
            gameObject.transform.GetChild(3).gameObject.transform.Find("InvImage").GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.GetChild(3).gameObject.transform.Find("ExitImage").GetComponent<BoxCollider>().enabled = false;
            //gameObject.GetComponent<CharacterController>().enabled = true;
            //gameObject.GetComponent<Rigidbody>().isKinematic=false;
            //hotbarUI.SetActive(false);
            //flag = false;
        }
        if(Input.GetButton("ButtonA") && timePassed >= keyDelay){
            
            Debug.Log("joystick buttonA");
            
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hotbarUI.activeSelf == false) {
                    if(hitInfo.collider.GetComponent<Interactable>() != null) {
                        hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
                    }
                    else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                        hitInfo.collider.GetComponent<Equipable>().EquipPass();
                    }
                    else if(hitInfo.collider.GetComponent<Television>() != null) {
                        hitInfo.collider.GetComponent<Television>().TelevisionPass();
                    }
                    if(hitInfo.collider.tag == "Truck") {
                        SceneManager.LoadScene("Level-3-3");
                    }
                    if(hitInfo.collider.tag == "tent") {
                        SceneManager.LoadScene("Level-3 End");
                    }
                }
                else
                {
                    if(hitInfo.collider.tag == "Hotbar") {
                        itemChoose = hitInfo.collider.GetComponent<Interactable>().ClickItem();
                        if(String.Equals(itemChoose, "Whistle") && flashlight.activeSelf){
                            flashlight.SetActive(false);
                        }
                        hotbarUI.SetActive(false);
                    }
                }
                if (MainMenu.activeSelf == true) {
                    if(hitInfo.collider.tag == "Yes") {
                        SceneManager.LoadScene("mainmenu");
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory2sfx").GetComponent<AudioSource>().Play();
                    }
                    if(hitInfo.collider.tag == "No") {
                        Debug.Log("no click");
                        gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        MainMenu.SetActive(false);
                        gameObject.transform.GetChild(3).gameObject.transform.Find("inventory2sfx").GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<CharacterController>().enabled = true;
                    }
                }
            }
                

        timePassed = 0f;
        }
        
        if(Input.GetButton("ButtonB") && timePassed >= keyDelay){
            //gameObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log("joystick buttonB");
            if(String.Equals(itemChoose, "Flashlight")) {
                flashlight.SetActive(!flashlight.activeSelf);
            }
            if(String.Equals(itemChoose, "Whistle")) {
                Debug.Log("Whistle is used");
                whistle.Play();
            }
            timePassed = 0f;
        }
        if(Input.GetButton("ButtonY") && timePassed >= keyDelay){
            Debug.Log("joystick buttonY");
        timePassed = 0f;
        }
        if(Input.GetButton("ButtonX") && timePassed >= keyDelay){
            Debug.Log("joystick buttonX");
        timePassed = 0f;
        }
        if(Input.GetButton("ButtonStart") && timePassed >= keyDelay){
            Debug.Log("joystick buttonStart");
        timePassed = 0f;
        }
        if(Input.GetButton("ButtonSelect") && timePassed >= keyDelay){
            Debug.Log("joystick buttonSelect");
        timePassed = 0f;
        }
        if(pickDustpan == true && pickBroom == true){
            objectCheck.transform.GetChild(0).GetComponent<OutlineBorder>().enabled = true;
            objectCheck.transform.GetChild(1).GetComponent<OutlineBorder>().enabled = true;
            objectCheck.transform.GetChild(2).GetComponent<OutlineBorder>().enabled = true;
            objectCheck.transform.GetChild(3).GetComponent<OutlineBorder>().enabled = true;
            objectCheck.transform.GetChild(4).GetComponent<OutlineBorder>().enabled = true;
            objectCheck.transform.GetChild(5).GetComponent<OutlineBorder>().enabled = true;
        }
    
    }
    private void playerMove(){
        if(canMove){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
        if(controller.isGrounded == true && controller.velocity.magnitude>3f && gameObject.GetComponent<CharacterController>().enabled == true  && gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            footsteps.volume = UnityEngine.Random.Range(.8f,1f);
            footsteps.pitch = UnityEngine.Random.Range(.8f,1.1f);
            footsteps.enabled=true;
        }
        else{
            footsteps.enabled=false;
        }}
    }
    private void spawnInventory() {
        if(hotbarUI.activeSelf) {
            hotbarUI.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2;
            hotbarUI.transform.LookAt(new Vector3(gameObject.transform.position.x, hotbarUI.transform.position.y, gameObject.transform.position.z));
            hotbarUI.transform.forward *= -1;
            hotbarUI.transform.Rotate(70, 0, 0);
        }
        else if(MainMenu.activeSelf) {
            MainMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2;
            MainMenu.transform.LookAt(new Vector3(gameObject.transform.position.x, MainMenu.transform.position.y, gameObject.transform.position.z));
            MainMenu.transform.forward *= -1;
        }
    }
}