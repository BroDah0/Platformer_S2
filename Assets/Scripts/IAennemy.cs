using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class IAennemy : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Animator AnimController;
    Queue<Vector3> posPlayer = new Queue<Vector3>();
    Queue<bool> flipPlayer = new Queue<bool>();
    bool canFollow = false;
    bool Init = true;
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("Waiting", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer.Enqueue(Player.transform.position);
        flipPlayer.Enqueue(Player.GetComponent<SpriteRenderer>().flipX);
        if (canFollow)
        {
            
            transform.position = posPlayer.Dequeue();
            GetComponent<SpriteRenderer>().flipX = flipPlayer.Dequeue();
        }
        if (Init)
        {
            transform.Translate((Player.transform.position - transform.position)* 1.5f * Time.deltaTime, Space.World);
        }
    }

    void Waiting()
    {
        Init = false;
        canFollow = true;

    }
}
