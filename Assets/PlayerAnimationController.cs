using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //private PlayerMovmentScript movement;
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

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("run", movement.IsMoving());

        if (Input.GetButtonDown("Fire1"))
        {
            soundManager.PlaySFX(soundManager.fire);
            anim.SetTrigger("attack");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("attack2");

        }
            




    }
}
