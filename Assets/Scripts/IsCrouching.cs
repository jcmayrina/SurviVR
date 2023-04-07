using UnityEngine;
using TMPro;

public class IsCrouching : MonoBehaviour
{
    float crouchtimer;
    int mycrouchtimer;
    public TextMeshProUGUI textCrouch;
    public GameObject crouchInstructions;
    [SerializeField] private Animator myAnimController;
    // Start is called before the first frame update
    void Start()
    {
        textCrouch.SetText("");
        crouchInstructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            crouchtimer = 0;
            Debug.Log("Crouching under the table");
            crouchInstructions.SetActive(true);
            textCrouch.SetText("Please stay under the table until the earthquake calms down.");
            myAnimController.SetBool("showText",true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            crouchtimer += 1 * Time.deltaTime;
            mycrouchtimer = (int) crouchtimer;
            Debug.Log(mycrouchtimer);
            if(mycrouchtimer == 9) {
                myAnimController.SetBool("showText",false);
            }
            else if(mycrouchtimer == 10) {
                myAnimController.SetBool("showText",true);
                textCrouch.SetText("You can now carefully move and evacuate.");
            }
            else if(mycrouchtimer == 15) {
                myAnimController.SetBool("showText",false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            myAnimController.SetBool("showText",true);
            Debug.Log("Left under the table");
            crouchInstructions.SetActive(true);
            textCrouch.SetText("Find the exit and an open area to evacuate to.");
            Invoke("HideText",15);
        }
    }
    void HideText(){
            myAnimController.SetBool("showText",false);
    }
}