using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour


{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] public Rigidbody2D rigidbody;
    [SerializeField] private float jumpPower = 6f;
    [SerializeField] private GroundChecker groundChecker;
    
    public Animator anim;
    public GameObject AttackPoint;
    public float radius;
    public LayerMask enemies;

    public Transform sprite;

    private bool isJumping = false;

    public Vector3 input;
    public float KBForce;
    public float KBCounter;
    public float KBSTotalTime;

    public bool KnockFromRight;
    soundManager soundManager;

     void Start()
    {
        anim = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
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
            soundManager.PlaySFX(soundManager.jumpSound);
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
    public void attack() 
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(AttackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameobject  in enemy)
        {
            Debug.Log("HIT");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.transform.position, radius);
    }

    private void FixedUpdate()
    {
        if(KBCounter <= 0) 
        {
            Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y);
        }
        else 
        {
            if (KnockFromRight == true)
            {
                rigidbody.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false) 
            {
                rigidbody.velocity = new Vector2(KBForce, KBForce); 
            }
            KBCounter -= Time.deltaTime;
        }

        


        if (isJumping) 
        {
            rigidbody.AddForce(new Vector2 (0, jumpPower), ForceMode2D.Impulse);
            isJumping= false;

        }
    }
   
}
