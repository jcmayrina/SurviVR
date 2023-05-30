using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TVfreeze : MonoBehaviour
{
    Camera m_MainCamera;
    float crouchtimer;
    int mycrouchtimer;
    public GameObject Player;
    public GameObject tvcondition;
    public GameObject outsidecondition;
    public VideoPlayer video;
    private bool checkPlay=false;
    private bool checkPlay1=false;
    private float keyDelay = .2f;
    private float timePassed = 0f;
    //-----Serialize Fields for Raycast
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private LayerMask mask;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance);
        if(Physics.Raycast(ray, out hitInfo, maxDistance, mask)) {
            if(hitInfo.collider.tag == "TV") {
                if(Input.GetButton("ButtonA") && timePassed >= keyDelay){
                    if(video.isPlaying==false){
                        video.Play();
                        checkPlay = true;
                    }
                    timePassed = 0f;
                }
            }
            if(hitInfo.collider.tag == "TVLast") {
                if(Input.GetButton("ButtonA") && timePassed >= keyDelay){
                    if(video.isPlaying==false){
                        video.Play();
                        checkPlay1 = true;
                    }
                    timePassed = 0f;
                }
            }
        }
        if(checkPlay){
        crouchtimer += 1 * Time.deltaTime;
        mycrouchtimer = (int) crouchtimer;
        if(mycrouchtimer > 64){
            tvcondition.SetActive(false);
            outsidecondition.SetActive(true);
            TurnOnControls();
        }
        else if(mycrouchtimer < 64){
            Player.transform.position = new Vector3(8.040624f,6.198272f,-19.00196f);
            m_MainCamera.transform.rotation = Quaternion.Euler(new Vector3(6.9f,-90f,0f));
            TurnOffControls();
        }
        }
        
        if(checkPlay1){
        crouchtimer += 1 * Time.deltaTime;
        mycrouchtimer = (int) crouchtimer;
        if(mycrouchtimer > 5){
             SceneManager.LoadScene("Level-1 End");
        }
        else if(mycrouchtimer < 5){
            Player.transform.position = new Vector3(8.040624f,6.198272f,-19.00196f);
            m_MainCamera.transform.rotation = Quaternion.Euler(new Vector3(6.9f,-90f,0f));
            TurnOffControls();
        }
        }
    }
    public void TurnOffControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
        Player.gameObject.GetComponent<Rigidbody>().isKinematic=true;
    }

    public void TurnOnControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
        Player.gameObject.GetComponent<Rigidbody>().isKinematic=false;
    }
}
