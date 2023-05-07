
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   
    public Transform head;
    public GameObject hotbarUI;
    public GameObject flashlight;
    public String itemChoose="";
    public float speed = 5f;
    private float gravity = 10f;
    public CharacterController rigidbodyfreeze;
    Rigidbody myRb;
    public Image img;
    private Camera cam;
    private PlayerUI playerUI;
    private Animation anim;
    private bool isActive;
    private bool isAvailable;

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
        if(Input.anyKeyDown)
    Debug.Log(Input.inputString);
        playerControls = new PlayerInputActions();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerUI = GetComponent<PlayerUI>();
        myRb = GetComponent<Rigidbody>();
        flashlight.SetActive(false);
        hotbarUI.SetActive(false);
        cam = Camera.main;
    }
    void Update(){
        playerMove();
        playerUI.UpdateText(string.Empty);
        img.gameObject.SetActive(false);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                
                if(hitInfo.collider.tag == "Hotbar"){
                itemChoose = hitInfo.collider.GetComponent<Interactable>().ClickItem();
                hitInfo.collider.GetComponentInChildren<Animation>().Play("InventorySelected");
                }
                img.gameObject.SetActive(true);
            }


            else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Equipable>().promptMessage);
                img.gameObject.SetActive(true);
            }


            else if(hitInfo.collider.GetComponent<Television>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Television>().promptMessage);
                img.gameObject.SetActive(true);
            }
        }
        if(hotbarUI.activeSelf) {
            hotbarUI.transform.LookAt(new Vector3(head.position.x, hotbarUI.transform.position.y, head.position.z));
            hotbarUI.transform.forward *= -1;
            hotbarUI.transform.Rotate(90, 0, 0);
        }
        if(Input.GetButton("ButtonA")){
            
            if(hotbarUI.activeSelf) {
                    itemChoose = hitInfo.collider.GetComponent<Interactable>().ClickItem();
                    Debug.Log(itemChoose);
            }
            else {
                Debug.Log("joystick buttonA");

                if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                    if(hitInfo.collider.GetComponent<Interactable>() != null) {
                        hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
                    }

                    else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                        hitInfo.collider.GetComponent<Equipable>().EquipPass();
                        
                        if(string.Equals(hitInfo.collider.name, "Go Bag")) {
                            Debug.Log(string.Equals(hitInfo.collider.name, "Go Bag"));
                            // isAvailable = !isAvailable;
                        }
                        else {
                            Debug.Log(string.Equals(hitInfo.collider.name, "Go Bag"));
                        }
                    }

                    else if(hitInfo.collider.GetComponent<Television>() != null) {
                        hitInfo.collider.GetComponent<Television>().TelevisionPass();
                    }
                }
        }
        }
        
        if(Input.GetButton("ButtonB")){
            rigidbodyfreeze.enabled = true;
            Debug.Log("joystick buttonB");
        }
        if(Input.GetButton("ButtonY")){
            Debug.Log("joystick buttonY");
            if(hotbarUI.activeSelf) {
                if(itemChoose.Equals("slot1")) {
                    Debug.Log("Flashlight");
                    itemChoose = "slot2";
                }
                else if(itemChoose.Equals("slot2")) {
                    Debug.Log("Hand");
                    itemChoose = "";
                }
                else {
                    Debug.Log("Whistle");
                    itemChoose = "slot1";
                }
            }
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hitInfo.collider.GetComponent<Television>() != null) {
                    hitInfo.collider.GetComponent<Television>().TelevisionPass();
                }
            }
        }
        if(Input.GetButton("ButtonX")){
            Debug.Log("joystick buttonX");
            isActive = !hotbarUI.activeSelf;
            hotbarUI.SetActive(isActive);
            hotbarUI.transform.position = head.position + new Vector3(head.forward.x, (head.forward.y - 1), head.forward.z).normalized * 2;
        }
        if(Input.GetButton("ButtonStart")){
            Debug.Log("joystick buttonStart");
        }
        if(Input.GetButton("ButtonSelect")){
            Debug.Log("joystick buttonSelect");
        }
    }

    private void playerMove(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }

}