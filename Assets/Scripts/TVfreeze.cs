using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class TVfreeze : MonoBehaviour
{
    float crouchtimer;
    int mycrouchtimer;
    public GameObject Player;
    public VideoPlayer video;
    private bool checkPlay=false;
    private float keyDelay = .1f;
    private float timePassed = 0f;
    //-----Serialize Fields for Raycast
    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private LayerMask mask;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
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
                        Player.transform.position = new Vector3(8.040624f,6.198272f,-19.00196f);
                        Player.transform.rotation = Quaternion.Euler(new Vector3(6.9f,-90f,0f));
                    }
                    else{
                        video.Pause();
                        TurnOnControls();
                    }
                    timePassed = 0f;
                }
            }
        }
        if(checkPlay){
        crouchtimer += 1 * Time.deltaTime;
        mycrouchtimer = (int) crouchtimer;
        if(mycrouchtimer > 64){
            TurnOnControls();
        }
        else if(mycrouchtimer < 64){
        }
        }
    }
    public void TurnOffControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = false;
    }

    public void TurnOnControls()
    {
        Player.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
