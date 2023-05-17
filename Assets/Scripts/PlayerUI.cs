using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    PlayerMovement player;
    private TextMeshProUGUI promptText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    void Update() {
        Debug.Log(player.itemName);
        if(player.itemName != null)
        promptText = player.itemName.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage) {
        promptText.SetText(promptMessage);
    }
}
