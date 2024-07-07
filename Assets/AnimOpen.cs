using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOpen : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            animator.SetBool("IsOpened", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
