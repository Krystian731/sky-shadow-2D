using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    private Animator enemyAnimator;
    public soundManager soundManager;
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point") 
        {
            soundManager.PlaySFX(soundManager.deadEnemy);
            enemyAnimator.SetTrigger("Die");
           Destroy(collision.gameObject);

        }
        
    }
}
