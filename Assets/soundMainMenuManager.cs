using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundMainMenuManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSourceMenu;
    public AudioClip background;
    void Start()
    {
        musicSourceMenu.clip = background;
        musicSourceMenu.Play();
    }


}
