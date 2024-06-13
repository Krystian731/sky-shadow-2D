using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform currentPoint;
    public float speed;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("run", true);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (isChasing) 
        {
            if (transform.position.x > playerTransform.position.x)
            {
                flip();
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                flip();
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        else 
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance) 
            {
                isChasing = true;
            }

            
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)

            {
                flip();
                currentPoint = pointB.transform;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {
                flip();
                currentPoint = pointA.transform;
            }
        }

       
   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.3f);
       Gizmos.DrawWireSphere(pointB.transform.position, 0.3f);
       Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    private void flip() 
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
