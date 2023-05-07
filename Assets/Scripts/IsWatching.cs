using UnityEngine;
using TMPro;

public class IsWatching : MonoBehaviour
{
    float timer;
    int mytimer;
    public TextMeshProUGUI textWatch;
    public GameObject bgColor;
    [SerializeField] private Animator myAnimController;
   
    
    void Start()
    {
        textWatch.SetText("");
        bgColor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        mytimer = (int) timer;
        //Debug.Log(mytimer);
        if(mytimer==10){
        bgColor.SetActive(true);
        textWatch.SetText("Press 'B' to move around while watching.");
        myAnimController.SetBool("showText",true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
    }
    void OnTriggerStay(Collider other)
    {
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            Debug.Log("left the tv area");
            bgColor.SetActive(true);
            textWatch.SetText("Listen to the information from the news.");
            myAnimController.SetBool("showText",true);
            Invoke("HideText",15);
        }
    }
    void HideText(){
            myAnimController.SetBool("showText",false);
    }
}