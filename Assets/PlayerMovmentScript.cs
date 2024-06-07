using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour


{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float jumpPower = 6f;
    [SerializeField] private GroundChecker groundChecker;
    
    public Animator anim;

    public Transform sprite;

    private bool isJumping = false;

    public Vector3 input;

     void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        input = new Vector3(inputX, inputY, 0);

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded())
        {
            isJumping = true;
        }

        if(input.x < 0f)
        {
            sprite.localScale = new Vector3(-0.1901725f, 0.1901725f, 0.1901725f);
        }
        if (input.x > 0f) 
        {
            sprite.localScale = new Vector3(0.1901725f, 0.1901725f, 0.1901725f);
        }

        anim.SetBool("run", Mathf.Abs(input.x) > 0.1f);
    }

    private void FixedUpdate()
    {
        Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
        rigidbody.velocity = new Vector2 (move.x, rigidbody.velocity.y);


        if (isJumping) 
        {
            rigidbody.AddForce(new Vector2 (0, jumpPower), ForceMode2D.Impulse);
            isJumping= false;
        }
    }
}
