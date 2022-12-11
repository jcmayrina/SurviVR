using UnityEngine;
using TMPro;

public class IsCrouching : MonoBehaviour
{
    float crouchtimer;
    int mycrouchtimer;
    public TextMeshProUGUI textCrouch;
    public GameObject crouchInstructions;
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
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            crouchtimer += 1 * Time.deltaTime;
            mycrouchtimer = (int) crouchtimer;
            Debug.Log(mycrouchtimer);
            if(mycrouchtimer == 10) {
                textCrouch.SetText("You can now carefully move and evacuate.");
            }
            else if(mycrouchtimer == 15) {
                textCrouch.SetText("");
                crouchInstructions.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Left under the table");
            crouchInstructions.SetActive(true);
            textCrouch.SetText("Find the exit and an open area to evacuate to.");
            Invoke("HideExitText",15);
        }
    }
    void HideExitText(){
        crouchInstructions.SetActive(false);
        textCrouch.SetText("");
    }
}