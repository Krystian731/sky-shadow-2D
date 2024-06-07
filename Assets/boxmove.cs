using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmove : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Rigidbody2D rigidbody;

    private Vector3 input;
    // Start is called before the first frame update
    void Start()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        input = new Vector3(inputX, inputY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
        rigidbody.velocity = move;
    }
}