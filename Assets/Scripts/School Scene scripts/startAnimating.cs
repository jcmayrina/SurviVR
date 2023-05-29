using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimating : MonoBehaviour
{
    public Animation animate;
    // Start is called before the first frame update
    void Awake()
    {

        AnimationClip clipToPlay = animate.GetClip(animate.clip.name);       
        clipToPlay.wrapMode = WrapMode.Loop;

        animate.Play(); 

    }

    void Start() 
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
