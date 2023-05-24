using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderActTrigger : MonoBehaviour
{
    public GameDirector gdFunction;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter() {
        gdFunction.playerTriggerThis();
        gameObject.SetActive(false);
    }
}
