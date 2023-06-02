using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding;
using System;

public class IaAstarothmieux : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Animator animController;
    Rigidbody2D rb;
    Queue<Vector3> posPlayer = new Queue<Vector3>();
    //Queue<bool> flipPlayer = new Queue<bool>();
    bool canFollow = false;
    bool Init = true;
    float horizontal_value;
    float vertical_value;
    Vector2 ref_velocity = Vector2.zero;
    Vector2 target_velocity;
    public PlayerHealth PlayerHealth;
    public CinemachineSwitcherCam cam;

    public Vector2 StartPos;

    bool isTimed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        StartPos = transform.position;
        Invoke("Waiting", UnityEngine.Random.Range(0.4f, 0.8f));
    }

    private void Awake()
    {

        Player = GameObject.Find("ALEX");
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Player.gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        posPlayer.Enqueue(Player.transform.position);


        //flipPlayer.Enqueue(Player.transform.localScale.);
        //scale- 

        if (canFollow)
        {
            transform.position = posPlayer.Dequeue();
            
            //GetComponent<SpriteRenderer>().flipX = flipPlayer.Dequeue();
        }
        if (Init)
        {
            StartCoroutine(Timer());
            if (isTimed)
            {
                transform.Translate((Player.transform.position - transform.position) * 4f * Time.deltaTime, Space.World);                      
            }

            animController.SetFloat("SpeedAstaroth", Mathf.Abs(1f));
            isTimed = false;
            
        }

        /*if(PlayerHealth.currentHealth == 0)
        {
            Destroy(GameObject.FindWithTag("Astaroth"));
        }*/

        /*if (Player.rb.velocity.y > 0.1f )
        {
            animController.SetBool("Jump", true);
        }*/
    }

    void Waiting()
    {
        Init = false;
        canFollow = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.5f);
        isTimed = true;
    }
}
