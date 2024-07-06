using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class openChest : MonoBehaviour
{
private Animator anim;

    void Start()
    {
     anim = GetComponent<Animator>();   
    }

    private void OnCollisionEnter2D(Collision2D box)
    {
        if (box.gameObject.CompareTag("Player"))
        {
          anim.SetBool("IsOpened", true);
        }
    }

    void Update()
    {
        
    }
}
