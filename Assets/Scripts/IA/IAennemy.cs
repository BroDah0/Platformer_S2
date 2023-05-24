using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding;

public class IAennemy : MonoBehaviour
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

    public Vector2 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        StartPos = transform.position;
        Invoke("Waiting", 0.6f);
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
        
        if (canFollow)
        {
            transform.position = posPlayer.Dequeue();
            //GetComponent<SpriteRenderer>().flipX = flipPlayer.Dequeue();
        }
        if (Init)
        {
            transform.Translate((Player.transform.position - transform.position)* 2f * Time.deltaTime, Space.World);
            animController.SetFloat("Speed", Mathf.Abs(2f));
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ZoneCameraProche")
        {
            Destroy(gameObject);
        }
    }
}
