using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float gravity = 10f;
    private CharacterController controller;
    public PlayerInputActions playerControls;
    Rigidbody myRb;
    private InputAction fire;
    public Image img;
    private Camera cam;
    private PlayerUI playerUI;
    //private InputManager inputManager;
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
    }
    private void OnDisable()
    {
        fire.Disable();
    }
    void Start()
    {
        controller =  GetComponent<CharacterController>();
        myRb = GetComponent<Rigidbody>();
        cam = Camera.main;
        playerUI = GetComponent<PlayerUI>();
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
                img.gameObject.SetActive(true);
            }
        }
        
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Equipable>() != null) {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Equipable>().promptMessage);
                img.gameObject.SetActive(true);
            }
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
    private void Fire(InputAction.CallbackContext context){
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                hitInfo.collider.GetComponent<Interactable>().HideDoorPass();
            }
        }
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Equipable>() != null) {
                hitInfo.collider.GetComponent<Equipable>().EquipPass();
            }
        }
    }
}