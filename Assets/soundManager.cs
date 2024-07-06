using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource gameOverAudioSource;
    [SerializeField] AudioSource winGameAudioSource;
    [SerializeField] AudioSource openChestAudioSource;

    public AudioClip backgroung;
    public AudioClip fire;
    public AudioClip jumpSound;
    public AudioClip deadPlayer;
    public AudioClip deadEnemy;
    public AudioClip gameOver;
    public AudioClip winGame;
    public AudioClip openChest;

    private void Start()
    {
        musicSource.clip = backgroung;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayGameOver(AudioClip clip) 
    {
        gameOverAudioSource.PlayOneShot(clip);
    }
    public void PlayWinGame(AudioClip clip)
    {
        winGameAudioSource.PlayOneShot(clip);
    }
    public void PlayOpenChest(AudioClip clip)
    {
        openChestAudioSource.PlayOneShot(clip);
    }
}

