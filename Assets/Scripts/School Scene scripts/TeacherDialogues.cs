using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherDialogues : MonoBehaviour
{
    public AudioSource TeacherDialogue;
    [SerializeField] private List<AudioSource> Dialogues;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDialogAudio(int index) {
        Dialogues[index].Play();
    }
}
