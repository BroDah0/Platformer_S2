using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemy : MonoBehaviour
{
    public Rigidbody2D ennemy;
    public EnnemyManager EnnemyManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D Ennemy = Instantiate(ennemy, transform.position, transform.rotation);
            EnnemyManager.EnnemyNB += 1;
            Ennemy.name = "Ennemy_" + EnnemyManager.EnnemyNB;
            GetComponent<BoxCollider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject);

        }
    }

    
}
