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
    Rigidbody myRb;
    private InputAction fire;
    private InputAction inventory;
    public Image img;
    private Camera cam;
    private PlayerUI playerUI;
    private Inventory setInventory;

    //Editable component values
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

        inventory = playerControls.Player.Inventory;
        inventory.Enable();
        inventory.performed += openInventory;
    }
    private void OnDisable()
    {
        fire.Disable();
    }
    void Start()
    {
        controller =  GetComponent<CharacterController>();
        myRb = GetComponent<Rigidbody>();
        playerUI = GetComponent<PlayerUI>();
        setInventory = GetComponent<Inventory>();
        cam = Camera.main;
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

        //If the object is interactable
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                img.gameObject.SetActive(true);
            }
        }
        
        //If the object is equipable
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Equipable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Equipable>().promptMessage);
                img.gameObject.SetActive(true);
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