using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour
{
    //  Public Objects
    public GameObject goBag;
    public GameObject hotbarUI;
    public GameObject Player;
    public GameObject Teacher;
    public GameObject TextDialogueGuide;
    public TextMeshProUGUI Dialogue;
    public TextMeshProUGUI ObjectiveText;

    // Object Reference
    private Transform cam;
    private Animation TextBoxAnimation;
    private GameObject TextDialogue;
    private AudioClip audioClip;

    // Private Variables
    private bool goBagFlag = true;
    private bool continueDialogue = true;
    private string sceneName;
    private string currentDialogue;
    private int index, itemClick;
    private float keyDelay = .2f;
    private float keyPassed = 0f;
    private float textDelay = 7f;
    private float textDelay2 = 12f;
    private float idleLength = 0f;

    // Public Variables
    public bool activateTimer = false;
    public List<GameObject> Colliders;
    
    [SerializeField] private List<String> Dialogues;

    void Awake() {

        TextDialogue = TextDialogueGuide.transform.GetChild(0).gameObject; // Canvas Object
        TextBoxAnimation = TextDialogue.GetComponent<Animation>(); // RawImage Animation 
        Dialogue = TextDialogue.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextDialogue.SetActive(false);
        cam = Player.transform.GetChild(0).gameObject.transform; // Main Camera as GameObject
    
    }

    // Start is called before the first frame update
    void Start() {

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

        // Set all colliders to inactive 
        for(int i = 0; i < Colliders.Count; i++) {
            Colliders[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Static Methods
        if(activateTimer) {
            setTimer();
        }
        textLookAtPlayer();
        
        // Exclusive for "SchoolScene Act1" scene
        if(String.Equals(sceneName, "SchoolScene Act1")) {
            if(goBagFlag) {
                afterGobagInactive();
            }

            if(continueDialogue){
                sceneOneDialogueFlow();
            }

            beforeGoBagInactive();
        }

        // Exclusive for "SchoolScene Act2" scene
        if(String.Equals(sceneName, "SchoolScene Act2")) {

            keyPassed += Time.deltaTime;

            if(continueDialogue) {
                sceneTwoDialogueFlow();
            }

            if(index == 3 && String.Equals(Player.GetComponent<PlayerMovement>().itemChoose, "Flashlight")) {
                if(Input.GetButton("ButtonA") && keyPassed >= keyDelay && hotbarUI.activeSelf == false) {
                    itemClick++;
                    keyPassed = 0f;
                }

                if(itemClick == 3) {
                    itemClick = 0;
                    index++;
                    continueDialogue = true;
                }
            }

            if(index == 5 && String.Equals(Player.GetComponent<PlayerMovement>().itemChoose, "Whistle")) {
                if(Input.GetButton("ButtonA") && keyPassed >= keyDelay && hotbarUI.activeSelf == false) {
                    itemClick++;
                    keyPassed = 0f;
                }

                if(itemClick == 3) {
                    itemClick = 0;
                    ++index;
                    Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
                    Invoke("LoadNextScene", 43f);
                }
            }
        }
    }

    // Teacher's dialogue flow in scene 1
    private void sceneOneDialogueFlow() {
        if(index == 0 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            index++;
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
        }
        else if(index == 1 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            Player.GetComponent<CharacterController>().enabled = true;
            Colliders[1].SetActive(true);
            currentDialogue = Dialogues[1];
            activateTimer = true;
            continueDialogue = false;
        }
        else if(index == 2 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
            Colliders[0].SetActive(true);
            currentDialogue = Dialogues[3];
            activateTimer = true;
            continueDialogue = false;
        }
    }

    private void sceneTwoDialogueFlow() {
        if(index == 3 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            currentDialogue = Dialogues[4];
            activateTimer = true;
            continueDialogue = false;
        }
        else if(index == 4 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            Teacher.GetComponent<TeacherDialogues>().playDialogAudio(index);
            index++;
            continueDialogue = false;
        }
        else if(index == 5 && !Teacher.GetComponent<AudioSource>().isPlaying) {
            currentDialogue = Dialogues[5];
            activateTimer = true;
            continueDialogue = false;
        }
    }

    private void beforeGoBagInactive() {

        if(goBag.activeSelf && hotbarUI.activeSelf) {
            hotbarUI.transform.GetChild(0).gameObject.SetActive(false);
            hotbarUI.transform.GetChild(2).gameObject.SetActive(false);
        }
        else {
            hotbarUI.transform.GetChild(0).gameObject.SetActive(true);
            hotbarUI.transform.GetChild(2).gameObject.SetActive(true);
        }

    }

    private void afterGobagInactive() {

        if(!goBag.activeSelf){
            index++;
            goBagFlag = !goBagFlag;
            continueDialogue = true;

            if(TextDialogue.activeSelf) {
                TextBoxAnimation.Play("TextBoxClose");
            }
        }

    }

    // Triggers when Text Box is active. Always looking on Player's direction
    private void textLookAtPlayer() {
        if(TextDialogue.activeSelf) {
            TextDialogue.transform.LookAt(new Vector3(cam.transform.position.x, TextDialogue.transform.position.y, cam.transform.position.z));
            TextDialogue.transform.forward *= -1;
        }
    }

    // Spawn Text Guide Dialogue Text Box in front of Player
    private void spawnTextGuide() {
        TextDialogue.transform.position = cam.position + new Vector3(cam.forward.x, 0, cam.forward.z).normalized * 3f;
        Dialogue.SetText(currentDialogue);
        ObjectiveText.SetText("- " + currentDialogue);
    }

    // Sets timer to show text dialogue in front of player when idle or not doing the objetive. Show after 5sec, hide after another 5sec
    private void setTimer() {
        idleLength += Time.deltaTime;

        if(idleLength >= textDelay && !TextDialogue.activeSelf) {
            TextDialogue.SetActive(true);
            spawnTextGuide();
        }
        if(idleLength >= textDelay2 && TextDialogue.activeSelf) {
            TextBoxAnimation.Play("TextBoxClose");
            activateTimer = false;
            idleLength = 0f;
        }
    }
    
    // Trigger this set of methods when Player triggers any collider
    public void setTriggeredCollider(int colliderIndex) {   

        switch (colliderIndex)
        {
            case 0:
                SceneManager.LoadScene("SchoolScene Act2");
            break;
            case 1:
                idleLength = 0f;
                currentDialogue = Dialogues[2];
                activateTimer = true;  

                if(TextDialogue.activeSelf) {
                    TextDialogue.SetActive(false);
                }
            break;
            
            default:

            break;
        }

    }

    private void LoadNextScene() {
        SceneManager.LoadScene("SchoolScene End");
    }
}
