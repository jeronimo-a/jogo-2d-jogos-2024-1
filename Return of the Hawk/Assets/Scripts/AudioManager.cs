using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;
    
    public AudioClip background;
    public AudioClip shot;

    //public AudioClip walk;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
