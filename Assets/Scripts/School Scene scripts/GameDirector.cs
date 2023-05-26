using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject goBag;
    public GameObject hotbarUI;
    public GameObject colliderActTrigger;
    public GameObject Player;
    public Animation sceneTransition;
    public GameObject Teacher;

    private bool goBagFlag = true;
    private bool isTriggered = false;
    private string sceneName;
    private int index, itemClick;
    private float keyDelay = .2f;
    private float timePassed = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Player.GetComponent<CharacterController>().enabled = false;

        if(sceneName == "SchoolScene Act1") {
            index = 0;
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
        }

        if(sceneName == "SchoolScene Act2") {
            index = 3;
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        
        if(sceneName == "SchoolScene Act1") {
            sceneOneDialogueFlow();
            if(goBag.activeSelf && hotbarUI.activeSelf) {
                hotbarUI.transform.GetChild(0).gameObject.SetActive(false);
                hotbarUI.transform.GetChild(2).gameObject.SetActive(false);
            }
            else {
                hotbarUI.transform.GetChild(0).gameObject.SetActive(true);
                hotbarUI.transform.GetChild(2).gameObject.SetActive(true);
            }
            if(!goBag.activeSelf && goBagFlag) {
                index++;
                Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
                colliderActTrigger.SetActive(true);
                goBagFlag = !goBagFlag;
            }
            if(isTriggered) {
                SceneManager.LoadScene("SchoolScene Act2");
            }
        }
        if(sceneName == "SchoolScene Act2") {
            sceneOneDialogueFlow();
            Player.GetComponent<CharacterController>().enabled = false;
            if(index == 3 && String.Equals(Player.GetComponent<PlayerMovement>().itemChoose, "Flashlight")) {
                if(Input.GetButton("ButtonA") && timePassed >= keyDelay && hotbarUI.activeSelf == false) {
                    itemClick++;
                    
                    timePassed = 0f;
                }

                if(itemClick == 2) {
                    itemClick = 0;
                    index++;
                    Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
                }
            }
            else if(index == 4 && String.Equals(Player.GetComponent<PlayerMovement>().itemChoose, "Whistle")) {
                if(Input.GetButton("ButtonA") && timePassed >= keyDelay && hotbarUI.activeSelf == false) {
                    itemClick++;

                    timePassed = 0f;
                }
                if(itemClick == 2) {
                    itemClick = 0;
                    index++;
                    Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
                }
            }
        }
    }

    public void playerTriggerThis() {
        isTriggered = true;
        Player.GetComponent<CharacterController>().enabled = false;
    }

    private void sceneOneDialogueFlow() {
        if(index == 0 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            index++;
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
        }
        if(index == 1 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            Player.GetComponent<CharacterController>().enabled = true;
        }
        if(index == 5 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            Debug.Log("Test");
        }
    }
}
