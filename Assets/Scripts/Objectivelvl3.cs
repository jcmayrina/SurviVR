using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Objectivelvl3 : MonoBehaviour
{
    PlayerMovement player;
    public GameObject obj; 

    void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update() {
        Scene currentScene = SceneManager.GetActiveScene ();
        Dictionary<string,int> objectiveCount = new Dictionary<string, int>();
        foreach(string item in player.objectiveLists)
        {
            if (!objectiveCount.ContainsKey(item))
            {
                objectiveCount.Add(item,1);
            }
            else
            {
                int count = 0;
                objectiveCount.TryGetValue(item, out count);
                objectiveCount.Remove(item);
                objectiveCount.Add(item, count+1);
            }
        }
        // output the results, each item with quantity
        if(currentScene.name == "Level-3-1"){
        foreach(KeyValuePair<string,int> entry in objectiveCount)
        {
            Debug.Log(entry.Key + " x " + entry.Value);
            if(entry.Key == "phone"){
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "go bag"){
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "TV1"){
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "canned goods" && entry.Value == 7){
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "bottled water" && entry.Value == 5){
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "whistle"){
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "flashlight"){
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "evacuate"){
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            if(entry.Key == "tent"){
            obj.transform.GetChild(8).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(8).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
        }}
        if(currentScene.name == "Level-3-2"){
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        }
        
        if(currentScene.name == "Level-3-3"){
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(4).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(5).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(7).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(8).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(8).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(9).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(9).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            obj.transform.GetChild(10).GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
            obj.transform.GetChild(10).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        }
    }
}
