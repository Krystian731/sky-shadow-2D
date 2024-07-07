using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOpen : MonoBehaviour
{
    Animator animator;
    public gameManagerScript gameManagerScript;
    private soundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            animator.SetTrigger("open");
            soundManager.PlaySFX(soundManager.openChest);
            Invoke("winScreen", 1.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void winScreen() 
    {
        gameManagerScript.winGame();
    }
}
