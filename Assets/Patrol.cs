using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
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
        currentPoint = pointB.transform; // Ustawienie currentPoint na punkt B
        anim.SetBool("run", true);

    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 point = currentPoint.position - transform.position; // obliczanie wektora kierunku do currentPoint;
        if (isChasing) //Jeœli obiekt goni gracza;
        {
            if (transform.position.x > playerTransform.position.x) //Jeœli pozycja x obiektu jest wiêksza ni¿ pozycja x gracza.
            {
                flip();
                transform.position += Vector3.left * speed * Time.deltaTime; // Przemieszczenie obiektu w lewo.
            }
            if (transform.position.x < playerTransform.position.x) // Jeœli pozycja x obiektu jest mniejsza ni¿ pozycja x gracza.
            {
                flip();
                transform.position += Vector3.right * speed * Time.deltaTime; // Przemieszczenie obiektu w prawo.
            }
        }

        else 
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance) // Jeœli gracz jest w zasiêgu.
            {
                isChasing = true; // Ustawienie isChasing na true.
            }

            
            if (currentPoint == pointB.transform) // Jeœli obecny punkt to punkt B
            {
                rb.velocity = new Vector2(speed, 0); // Ustawienie prêdkoœci obiektu w prawo.
            }
            else // Jeœli obecny punkt to punkt A.
            {
                rb.velocity = new Vector2(-speed, 0); // Ustawienie prêdkoœci obiektu w lewo.
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform) // Jeœli obiekt jest blisko punktu A.

            {
                flip();
                currentPoint = pointB.transform; // Ustawienie currentPoint na punkt B.
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {
                flip();
                currentPoint = pointA.transform; // Ustawienie currentPoint na punkt A.
            }
        }

       
   
    }
    //wyrysowanie tych bia³ych okrêgów plus lini, nic wiêcej ten kod nie robi :).
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
