using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public PlayerBehaviourScript playerMovement;
    public bool facingRight;
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviourScript>();
        facingRight = playerMovement.sprite.localScale.x > 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
       if (projectileCount <= 0 )
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (facingRight)
        {
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
        }
        else
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
            

        }
        Destroy(gameObject);

    }
}
