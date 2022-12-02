using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{

    private PlayerAction playerAction;
    private PlayerAction.PlayerActActions playerAct;
    // Start is called before the first frame update
    void Awake()
    {
        playerAction = new PlayerAction();
        playerAct = playerAction.PlayerAct;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onEnable() {
        playerAct.Enable();
    }

    private void onDisable() {
        playerAct.Disable();
    }
}
