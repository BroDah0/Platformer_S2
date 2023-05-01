using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Objets
    CapsuleCollider2D cap;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    TrailRenderer tre;
    [SerializeField] GameObject aide;

    //Variables
    float horizontal_value;
    float vertical_value;
    Vector2 ref_velocity = Vector2.zero;
    Vector2 target_velocity;
    float jumpForce = 20f;
    [SerializeField] TrailRenderer tr;
    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [SerializeField] float sprintSpeed_horizontal = 600.0f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool grounded = false;
    [SerializeField] bool is_crouching = false;
    [SerializeField] bool is_sprinting = false;
    [SerializeField] private float slidingVelocity;
    [SerializeField] private float slidingTime = 0.3f;
    [SerializeField] private bool cooldownSprint = false;
    private Vector2 slidingDir;
    private bool is_sliding;
    private bool canSlide = true;
    [Range(0, 1)][SerializeField] float smooth_time = 0.5f;
    float Climb_speed = 150.0f;
    public bool isLadder = false;
    public bool canClimb = false;
    bool CheckSphere;
    private Vector2 aidepose;

    void Start()
    {
        cap = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        tre = GetComponent<TrailRenderer>();
        
    }

 
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");
        vertical_value = Input.GetAxis("Vertical");

        if (horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;

        //if (rb.velocity.y < 0) rb.gravityScale = 5;
        //else rb.gravityScale = 3;

        animController.SetFloat("Speed", Mathf.Abs(horizontal_value));

        // Sprint
        if (Input.GetButtonDown("Jump") && grounded && !is_crouching)
        {
            is_jumping = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (cooldownSprint == false)
            {
                is_sprinting = true;
                StartCoroutine(Sprint());

            }
            
        }

        // Crouch
        if (Input.GetButton("Crouch"))
        {
            is_crouching = true;
            is_sliding = false;
        }
        else
        {
            is_crouching = false;
        }

        // Slide
        if (Input.GetButtonDown("Slide") && canSlide && !is_crouching)
        {
            is_sliding = true;
            canSlide = false;
            cap.offset = new Vector2(22.30882f, -22.64283f);
            cap.size = new Vector2(57.15683f, 15.88799f);
            cap.direction = CapsuleDirection2D.Horizontal;
            tre.emitting = true;
            rb.gravityScale = 50f;
            slidingDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            if (slidingDir == Vector2.zero)
            {
                slidingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopSliding());

           
        }

        if (is_sliding)
        {
            rb.velocity = slidingDir.normalized * slidingVelocity;
            return;
        }

        /*if(grounded )
        {
            canSlide = true;
        }*/
    }
    
    void FixedUpdate()
    {       
        // Jump
        if (is_jumping && grounded && !canClimb)
        {           
            is_jumping = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animController.SetBool("Jumping", true);
            grounded = false;
        }

        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, rb.velocity.y);

        // Sprint
        if (is_sprinting)
        {
            target_velocity = new Vector2(horizontal_value * sprintSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        }

        // Crouch
        aidepose = new Vector2(aide.transform.position.x, aide.transform.position.y);
        CheckSphere = Physics2D.OverlapCircle(aidepose, 0.1f);
        if (is_crouching && grounded)
        {
            moveSpeed_horizontal = 200f;
            cap.offset = new Vector2(0.1f, -0.6f);
            cap.size = new Vector2(1.1f, 0.8f);
            cap.direction = CapsuleDirection2D.Horizontal;
            animController.SetBool("Crouching", true);
        }
        else if(CheckSphere == false)
        {
            is_crouching = false;
            moveSpeed_horizontal = 400f;
            cap.offset = new Vector2(0f, -0.35f);
            cap.size = new Vector2(1f, 1.3f);
            cap.direction = CapsuleDirection2D.Vertical;
            animController.SetBool("Crouching", false);
        }

        // Climb
        if (canClimb && vertical_value != 0)
        {
            rb.gravityScale = 0f;
            grounded = false;
            target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, vertical_value * Climb_speed * Time.deltaTime);
            animController.SetBool("Climbing", true);
        }
        
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);
    }
   
    // Slide coroutine
    IEnumerator stopSliding()
    {
        yield return new WaitForSeconds(slidingTime);
        tre.emitting = false;
        rb.gravityScale = 4;
        cap.offset = new Vector2(0.3032157f, -0.1786781f);
        cap.size = new Vector2(13.14533f, 59.856f);
        cap.direction = CapsuleDirection2D.Vertical;
        is_sliding = false;
        yield return new WaitForSeconds(3f);
        canSlide = true;

    }   

    // Sprint coroutine
    IEnumerator Sprint()
    {
        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        target_velocity = new Vector2(horizontal_value * sprintSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
        is_sprinting = false;
        cooldownSprint = true;
        yield return new WaitForSeconds(3f);
        cooldownSprint = false;
    }

    //Climbing
    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
        animController.SetBool("Jumping", false);

        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
            grounded = false;
        }       
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
            grounded = true;
            rb.gravityScale = 5f;
            animController.SetBool("Climbing", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        animController.SetBool("Jumping", false);    
    }
}