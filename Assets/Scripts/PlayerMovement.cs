
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   
    public Transform head;
    public GameObject hotbarUI;
    public GameObject flashlight;
    public String itemChoose = "";
    public float speed = 5f;
    private float gravity = 10f;
    Rigidbody myRb;
    private Camera cam;
    private Animation anim;
    private bool flag;
    private bool isAvailable;
    public AudioSource footsteps;
    private float keyDelay = .2f;
    private float timePassed = 0f;
    public bool canMove;
    public GameObject itemName;

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
        cam = Camera.main;
        itemChoose = "Hand";    
    }
    void Update(){
        timePassed += Time.deltaTime;
        playerMove();
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                if(hitInfo.collider.tag == "Hotbar"){
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
        
        if(head.eulerAngles.x >= 30 && head.eulerAngles.x <= 90) {
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            hotbarUI.SetActive(true);
            if(!flag) {
                spawnInventory();
                flag = true;
            }
            timePassed = 0f;
        }
    
        else {
            gameObject.GetComponent<CharacterController>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            hotbarUI.SetActive(false);
            flag = false;
            timePassed = 0f;
        }

        if(Input.GetButton("ButtonA") && timePassed >= keyDelay){
            
            if(hotbarUI.activeSelf) {
                itemChoose = hitInfo.collider.GetComponent<Interactable>().ClickItem();
                Debug.Log(itemChoose);
            }
            else {
                Debug.Log("joystick buttonA");

                if(String.Equals(itemChoose, "Hand")) {
                    if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                        if(hitInfo.collider.GetComponent<Interactable>() != null) {
                            hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
                        }

                        else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                            hitInfo.collider.GetComponent<Equipable>().EquipPass();
                            
                            // if(string.Equals(hitInfo.collider.name, "Go Bag")) {
                            //     Debug.Log(string.Equals(hitInfo.collider.name, "Go Bag"));
                            // }
                            // else {
                            //     Debug.Log(string.Equals(hitInfo.collider.name, "Go Bag"));
                            // }
                        }

                        else if(hitInfo.collider.GetComponent<Television>() != null) {
                            hitInfo.collider.GetComponent<Television>().TelevisionPass();
                        }
                    }
                }

                else if(String.Equals(itemChoose, "Flashlight")) {
                    if(gameObject.transform.GetChild(2).gameObject.activeSelf) {
                        gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    }
                    else {
                        gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    }
                }

                else if(String.Equals(itemChoose, "Whistle")) {
                    Debug.Log(itemChoose);
                }
            }
        
            timePassed = 0f;
        }
        if(Input.GetButton("ButtonB") && timePassed >= keyDelay){
            //gameObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log("joystick buttonB");
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
            
    }
    private void spawnInventory() {
        hotbarUI.transform.position = head.position + new Vector3(head.forward.x, head.forward.y, (head.forward.z - 1)).normalized * 1;
        hotbarUI.transform.LookAt(new Vector3(head.position.x, hotbarUI.transform.position.y, head.position.z));
        hotbarUI.transform.forward *= -1;
        hotbarUI.transform.Rotate(70, 0, 0);
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

}