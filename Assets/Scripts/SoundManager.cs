using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

   public  static SoundManager sound;
    public AudioSource coinSource;
    public AudioClip coinSound;

    private void Awake()

    {
        sound = this; 
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
