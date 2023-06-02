using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float coordonnee;
    private Vector3 respawnPoint;

    public HealthBar healthBar;
    public LayerMask zone_morte;
    public EnnemyManager EnnemyManager;
    private TakeDamage damage;
    IAennemy ennemy;

    public bool hitted = false;
    [SerializeField] float timerHit;
    [SerializeField] float timeBeforeHit = 3f;


    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnPoint= transform.position;
        ennemy = GetComponent<IAennemy>();
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
        // test pour voir si ca fonctionne
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
            Debug.Log("-1 health point");
        }

        if(currentHealth < 0) currentHealth = 0;
        if (currentHealth == 0)
        {
            //Debug.Log("c'est tipar");
            //ResetEnnemyPos();
            Debug.Log(transform.position);
            Debug.Log(respawnPoint);
            transform.position = respawnPoint;
            currentHealth = 3;
            healthBar.SetHealth(currentHealth);
        }

        /*if(damage.hitted)
        {
            TakeDamage(1);
        }*/
    }

    void FixedUpdate()
    {
        if (damage)
        {
            TakeDamage(1);
        }
    }    


    public void TakeDamage (int damage)
    {
        //Debug.Log(damage);
        currentHealth = currentHealth - damage;  // si on prends des degats ont retire de la vie a la vie actuelle
        healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie
        Debug.Log(currentHealth);

    }

    /*
    void ResetEnnemyPos()
    {
            for (int i = 1; i <= EnnemyManager.EnnemyNB; i++)
            {
                GameObject.Find("Ennemy_" + i).transform.position = GameObject.Find("Ennemy_" + i).GetComponent<IAennemy>().StartPos;
            }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
            Debug.Log("checkpoint");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        { 
                TakeDamage(3);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            if (!hitted)
            {
                TakeDamage(1);
                hitted = true;
            }
        }
        
        if (collision.gameObject.CompareTag("Astaroth"))
        {
            if (!hitted)
            {
                TakeDamage(2);
                hitted = true;
            }
        }
    }
}
