using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject goBag;
    public GameObject hotbarUI;
    public GameObject colliderActTrigger;
    public GameObject Canvas;
    public GameObject Player;
    public Animation sceneTransition;

    private bool goBagFlag = true;
    private bool hotBarUIFlag = true;
    private bool isStart = true;
    private bool sceneTransitionFlag = false;
    private bool isTriggered = false;
    private float timePassed = 0f;
    private string sceneName;
    private Vector3 colliderPosition;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName == "SchoolScene Act1") {
            if(goBag.activeSelf && hotbarUI.activeSelf) {
                hotbarUI.transform.GetChild(0).gameObject.SetActive(false);
                hotbarUI.transform.GetChild(2).gameObject.SetActive(false);
            }
            else {
                hotbarUI.transform.GetChild(0).gameObject.SetActive(true);
                hotbarUI.transform.GetChild(2).gameObject.SetActive(true);
            }
            if(!goBag.activeSelf && goBagFlag) {
                colliderActTrigger.SetActive(true);
                colliderPosition = colliderActTrigger.transform.position;
                playerPosition = Player.transform.position;
                goBagFlag = !goBagFlag;
            }
            if(isTriggered) {
                SceneManager.LoadScene("SchoolScene Act2");
            }
        }
        if(sceneName == "SchooldScene Act2") {
            if(isStart) {
                sceneTransition.Play("FadeOut");
                isStart = !isStart;
            }
        }
    }

    public void playerTriggerThis() {
        isTriggered = true;
        Canvas.SetActive(true);
        Player.GetComponent<CharacterController>().enabled = false;
    }
}