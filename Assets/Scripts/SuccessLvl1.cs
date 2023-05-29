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
        if(player.objectiveLists.Count==16){
            outsidecondition.SetActive(false);
            outsidecondition.transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
            outsidecondition.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            outsidecondition.transform.GetChild(1).GetComponent<MeshCollider>().enabled = false;
            outsidecondition.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
            outsidewarnings.SetActive(false);
        }
        if(player.objectiveLists.Count==24){
             SceneManager.LoadScene("Level-1 End");
        }
        
        foreach( var x in player.objectiveLists) {
            if(player.objectiveLists.Contains("dustpan"))
            player.pickDustpan = true;
            if(player.objectiveLists.Contains("broom"))
            player.pickBroom = true;
        }
    }
}