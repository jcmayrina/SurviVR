using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public Image img;
    private Camera cam;
    private PlayerUI playerUI;
    private SurviVR surviVR;
    private SurviVR.PlayerActions surviVRAct;
    private InputAction interact;
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private LayerMask mask;

    private void Awake(){
        surviVR = new SurviVR();
        surviVRAct = surviVR.Player;
    }

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        img.gameObject.SetActive(false);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                img.gameObject.SetActive(true);
                onEnable();
            }
        }
    }

    private void onEnable() {
        interact = surviVRAct.Fire;
        interact.Enable();
        interact.performed += Interact;
    }

    private void onDisable() {
        surviVRAct.Fire.Disable();
    }

    private void Interact(InputAction.CallbackContext context) {
        Debug.Log("HELLO");
    }
}
