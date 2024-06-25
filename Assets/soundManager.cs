using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroung;
    public AudioClip fire;
    public AudioClip jumpSound;
    public AudioClip deadPlayer;
    public AudioClip deadEnemy;

    private void Start()
    {
        musicSource.clip = backgroung;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
}

