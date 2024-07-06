using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOpen : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Vector2 playerPosition = collision.transform.position;
            Vector2 boxPosition = transform.position;

            bool isHit = playerPosition.y < boxPosition.y + 0.5f;
            if (isHit) 
            {
                animator.SetBool("AnimBox", true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
