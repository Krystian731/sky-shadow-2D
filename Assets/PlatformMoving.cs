using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public GameObject pointC;
    public GameObject pointD;
    private Rigidbody2D rigidbody2;
    public float speed;
    private Transform currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        currentPoint = pointC.transform;
        
    }

    // Update is called once per frame
    void Update()

    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;
        rigidbody2.MovePosition(newPosition);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            if (currentPoint == pointC.transform)
            {
                currentPoint = pointD.transform;
            }
            else
            {
                currentPoint = pointC.transform;
            }

        }
    }



        private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointC.transform.position, 0.3f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.3f);
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
    }
}
