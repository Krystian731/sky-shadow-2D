using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class openChest : MonoBehaviour
{
Animator anim;
soundManager soundManager;

private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
    }
    void Start()
    {
     anim = GetComponent<Animator>();   
    }

    private void OnCollisionEnter2D(Collision2D box)
    {
        if (box.gameObject.CompareTag("Player"))
        {
          anim.SetBool("IsOpened", true);
          soundManager.PlaySFX(soundManager.openChest);
        }
    }

    void Update()
    {
        
    }
}
