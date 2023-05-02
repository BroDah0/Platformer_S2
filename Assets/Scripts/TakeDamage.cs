using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] PlayerHealth PlayerHealth;
    [SerializeField] float timerHit;
    [SerializeField] float timeBeforeHit = 3;
    [SerializeField] bool hitted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitted)
        {
            if (timerHit < timeBeforeHit) timerHit += Time.deltaTime;
            if (timerHit > timeBeforeHit) timerHit = timeBeforeHit;
            if (timerHit == timeBeforeHit)
            {
                timerHit = 0;
                hitted = false;
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            if (!hitted)
            {
                PlayerHealth.TakeDamage(1);
                hitted = true;
            }

        }
    }



}
