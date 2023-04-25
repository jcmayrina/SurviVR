using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TVswitch : Television
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    protected override void TelevisionSwitch(){
        Debug.Log("tvswitch");
        SceneManager.LoadScene("Level-1 TV");
    }
}