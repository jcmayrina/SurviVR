using UnityEngine;
using TMPro;

public class IsCrouching : MonoBehaviour
{
    float countDown;
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
            countDown = 5.0f;
            Debug.Log("Crouching under the table");
            crouchInstructions.SetActive(true);
            textCrouch.SetText("Please stay under the table until the earthquake calms down.");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")){
            if(countDown > 0) {
                countDown -= Time.deltaTime;
            }
            else{
                Debug.Log("Time reached 5seconds");
                textCrouch.SetText("You can now carefully move and evacuate.");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("Left under the table");
            textCrouch.SetText("Find the exit and an open area to evacuate to.");
        }
    }
}
