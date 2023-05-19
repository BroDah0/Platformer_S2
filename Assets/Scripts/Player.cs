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
    [SerializeField] TrailRenderer tr;
    SprintBar sprint_bar;
    SlideBar slide_bar;
    [SerializeField] GameObject aide;

    //Variables
    float horizontal_value;
    float vertical_value;
    Vector2 ref_velocity = Vector2.zero;
    Vector2 target_velocity;
    private Vector2 slidingDir;

    float jumpForce = 18f;
    [SerializeField] float moveSpeed_horizontal = 650.0f;
    [SerializeField] float sprintSpeed_horizontal = 850.0f;
    [SerializeField] bool is_jumping = false;
    [SerializeField] bool grounded = false;
    [SerializeField] bool is_crouching = false;
    [SerializeField] bool is_sprinting = false;
    [SerializeField] private float slidingVelocity;
    [SerializeField] private float slidingTime = 0.4f;
    [SerializeField] private bool cooldownSprint = false;
    [SerializeField] private bool is_sliding;
    private bool canSlide = true;
    [Range(0, 1)][SerializeField] float smooth_time = 0.5f;
    float Climb_speed = 390.0f;
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
        sprint_bar = GetComponent<SprintBar>();
        slide_bar = GetComponent<SlideBar>();
    }

 
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");
        vertical_value = Input.GetAxis("Vertical");

        if (horizontal_value > 0) gameObject.transform.localScale = new Vector3(0.06f,0.06f,0);   //sr.flipX = false;
        else if (horizontal_value < 0) gameObject.transform.localScale = new Vector3(-0.06f,0.06f, 0);

        //if (rb.velocity.y < 0) rb.gravityScale = 5;
        //else rb.gravityScale = 3;

        animController.SetFloat("Speed", Mathf.Abs(horizontal_value));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded && !is_crouching)
        {
            is_jumping = true;
        }

        // Sprint
        if (Input.GetButton("Sprint") && grounded && !is_crouching)
        {
            if (cooldownSprint == false)
            {
                StartCoroutine(Sprint());
                is_sprinting = true;
                
            }
        }

        // Crouch
        if (Input.GetButton("Crouch") && grounded)
        {
            is_crouching = true;
            is_sliding = false;
        }
        else
        {
            is_crouching = false;
        }

        // Slide
        if (Input.GetButtonDown("Slide") && grounded && canSlide && !is_crouching && horizontal_value != 0)
        {
            StartCoroutine(Sliding());
            
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
        //aidepose = new Vector2(aide.transform.position.x, aide.transform.position.y);
        //CheckSphere = Physics2D.OverlapCircle(aidepose, 0.1f);
        if (is_crouching && grounded && !is_sliding)
        {
            moveSpeed_horizontal = 200f;
            cap.offset = new Vector2(0.3032135f, 5.344806f);
            cap.size = new Vector2(59.85606f, 10.40589f);
            cap.direction = CapsuleDirection2D.Horizontal;
            animController.SetBool("Crouching", true);
        }
        else if (!is_crouching && !is_sliding)
        {
            UnityEngine.Debug.Log("nan");
            is_crouching = false;
            moveSpeed_horizontal = 650f;
            cap.offset = new Vector2(0.3032157f, 30.07f);
            cap.size = new Vector2(13.14533f, 59.856f);
            cap.direction = CapsuleDirection2D.Vertical;
            animController.SetBool("Crouching", false);
        }

        // Climb
        if (canClimb && vertical_value != 0)
        {
            rb.gravityScale = 0f;
            grounded = false;
            target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * 0.5f * Time.deltaTime, vertical_value * Climb_speed * Time.deltaTime);
            animController.SetBool("Climbing", true);
        }
        
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);
    }
   
    // Slide coroutine 
    IEnumerator Sliding()
    {
        is_sliding = true;
        is_crouching = true;
        canSlide = false;
        cap.offset = new Vector2(0.3032135f, 5.344806f);
        cap.size = new Vector2(59.85606f, 10.40589f);
        cap.direction = CapsuleDirection2D.Horizontal;
        animController.SetBool("Sliding", true);
        tre.emitting = true;
        rb.gravityScale = 45f;
        slidingDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        yield return new WaitForSeconds(slidingTime);
        if (slidingDir == Vector2.zero)
        {
            slidingDir = new Vector2(transform.localScale.x, 0);
        }
        animController.SetBool("Sliding", false);
        tre.emitting = false;
        rb.gravityScale = 5.5f;
        is_sliding = false;
        is_crouching = false;
        StartCoroutine(slide_bar.SlideCooldown());
        yield return new WaitForSeconds(8f);
        canSlide = true;
    }

    // Sprint coroutine
    IEnumerator Sprint()
    {
        StartCoroutine(sprint_bar.SprintCooldown());
        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        target_velocity = new Vector2(horizontal_value * sprintSpeed_horizontal * Time.deltaTime, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
        is_sprinting = false;
        cooldownSprint = true;
        yield return new WaitForSeconds(10f);
        cooldownSprint = false;
    }

    //Climbing
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
            animController.SetBool("Jumping", false);
        }

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