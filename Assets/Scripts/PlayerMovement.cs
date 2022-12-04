using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 10f;

    private CharacterController controller;
<<<<<<< Updated upstream

    void Start()
    {
        controller = GetComponent<CharacterController>();
=======
    public PlayerInputActions playerControls;
    private InputAction fire;
<<<<<<< Updated upstream
    private InputAction inventory;
=======
    private InputAction navigate;
    Rigidbody myRb;
>>>>>>> Stashed changes
    public Image img;
    public Light light;
    private Camera cam;
    private PlayerUI playerUI;
<<<<<<< Updated upstream
    private Inventory setInventory;

    //Editable component values
=======
    public GameObject hotBarUI;
    public string thisButton = "";
    //private InputManager inputManager;
>>>>>>> Stashed changes
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private LayerMask mask;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

<<<<<<< Updated upstream
        inventory = playerControls.Player.Inventory;
        inventory.Enable();
        inventory.performed += openInventory;
=======
        navigate = playerControls.Player.Navigate;
        navigate.Enable();
        navigate.performed += Navigate;
>>>>>>> Stashed changes
    }
    private void OnDisable()
    {
        fire.Disable();
        navigate.Disable();
    }
    void Start()
    {
        controller =  GetComponent<CharacterController>();
        myRb = GetComponent<Rigidbody>();
        playerUI = GetComponent<PlayerUI>();
<<<<<<< Updated upstream
        setInventory = GetComponent<Inventory>();
        cam = Camera.main;
>>>>>>> Stashed changes
=======
        hotBarUI.gameObject.SetActive(false);
>>>>>>> Stashed changes
    }

    void Update(){
<<<<<<< Updated upstream
        Playermove();
    }
    void Playermove(){
=======
        playerMove();

        //Text Prompt
        playerUI.UpdateText(string.Empty);
        img.gameObject.SetActive(false);
        setInventory.gameObject.SetActive(false);

        //Raycast initial
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
<<<<<<< Updated upstream

        //If the object is interactable
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                img.gameObject.SetActive(true);
=======
        if(thisButton.Equals("")) {
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hitInfo.collider.GetComponent<Interactable>() != null) {
                    playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                    img.gameObject.SetActive(true);
                }
>>>>>>> Stashed changes
            }
        
<<<<<<< Updated upstream
        //If the object is equipable
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Equipable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Equipable>().promptMessage);
                img.gameObject.SetActive(true);
=======
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hitInfo.collider.GetComponent<Equipable>() != null) {
                    playerUI.UpdateText(hitInfo.collider.GetComponent<Equipable>().promptMessage);
                    img.gameObject.SetActive(true);
                }
>>>>>>> Stashed changes
            }
        }
    }

    //Player movement by controller
    private void playerMove(){
>>>>>>> Stashed changes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical);
        Vector3 velocity = direction*speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

    //Player interact
    private void Fire(InputAction.CallbackContext context){

        //Raycast initial
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);

        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            //If the object is interactable
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
            }
            //If the object is equipable
            else if(hitInfo.collider.GetComponent<Equipable>() != null) {
                hitInfo.collider.GetComponent<Equipable>().EquipPass();
                setInventory.active();
=======
    public void Fire(InputAction.CallbackContext context){
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(thisButton.Equals("")) {
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hitInfo.collider.GetComponent<Interactable>() != null) {
                    hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
                }
            }
            if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
                if(hitInfo.collider.GetComponent<Equipable>() != null) {
                    hitInfo.collider.GetComponent<Equipable>().EquipPass();
                    hotBarUI.gameObject.SetActive(true);
                }
            }
            else
                Debug.Log("There is no current item handled. Interact.");
        }
        else if(thisButton.Equals("HotbarSlot1") && hotBarUI.activeSelf) {
            Debug.Log("Current item is " + thisButton);
        }
        else if(thisButton.Equals("HotbarSlot2") && hotBarUI.activeSelf) {
            Debug.Log("Current item is " + thisButton);
            light.gameObject.GetComponent<Light>().enabled = !light.gameObject.GetComponent<Light>().enabled;
        }
    }

    public void Navigate(InputAction.CallbackContext context) {
        if(hotBarUI.activeSelf) {
            if(thisButton.Equals("HotbarSlot1")) {
                thisButton = "HotbarSlot2";
            }
            else if(thisButton.Equals("HotbarSlot2")) {
                thisButton = "";
            }
            else {
                thisButton = "HotbarSlot1";
>>>>>>> Stashed changes
            }
        }

        else {
            if(setInventory.gameObject.activeSelf == true) {
                Debug.Log("Item used!");
            }
        }
    }

    private void openInventory(InputAction.CallbackContext context) {
        
    }
>>>>>>> Stashed changes
}