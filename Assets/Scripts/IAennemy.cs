using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAennemy : MonoBehaviour
{
    [SerializeField] GameObject Player;
    Animator AnimController;
    Queue<Vector3> posPlayer = new Queue<Vector3>();
    Queue<bool> flipPlayer = new Queue<bool>();
    bool canFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Waiting", 1f);
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
    }

    void Waiting()
    {
        canFollow = true;
    }
}
