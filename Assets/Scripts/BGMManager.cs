using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip audioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSystem.SetBgm(audioSource);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
