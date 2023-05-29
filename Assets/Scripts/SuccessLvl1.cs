using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessLvl1 : MonoBehaviour
{
    PlayerMovement player;
    public GameObject outsidecondition;
    public GameObject outsidewarnings;
    float timer;
    int mytimer;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        mytimer = (int) timer;
        Debug.Log(player.objectiveLists.Count);
        if(player.objectiveLists.Count==16){
            outsidecondition.SetActive(false);
            outsidewarnings.SetActive(false);
        }
        if(player.objectiveLists.Count==22){
             SceneManager.LoadScene("Level-1 End");
        }
    }
}
