using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource a;
    public AudioClip c;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if(c != a.clip)
        {
            a.Play();
            c = a.clip;
        }    
    }
}
