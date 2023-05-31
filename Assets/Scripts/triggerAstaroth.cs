using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAstaroth : MonoBehaviour
{
    public Rigidbody2D astaroth;
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
        bool notSpawn = true;
        if (collision.gameObject.CompareTag("Player") )
        {
            if (notSpawn)
            {
                notSpawn = false;
                Rigidbody2D Astaroth = Instantiate(astaroth, transform.position, transform.rotation);
                Debug.Log(Astaroth.transform.position);
                Astaroth.transform.position = Vector3.zero;
                GetComponent<BoxCollider2D>().enabled = false;
                //this.enabled = false;
                //Destroy(gameObject);
                //Quaternion.Euler(0, 0, 0f)
            }
            

        }
    }
}
