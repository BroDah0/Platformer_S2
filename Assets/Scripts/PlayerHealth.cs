using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float coordonnee;
    private Vector3 respawnPoint;

    public HealthBar healthBar;
    public EnnemyManager EnnemyManager;

    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnPoint= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("c'est tipar");
            //ResetEnnemyPos();
            transform.position = respawnPoint;
            SceneManager.LoadScene("ASCENT");
        }
        // test pour voir si ca fonctionne
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
            Debug.Log("-1 health point");
        }
    }


    public void TakeDamage (int damage)
    {
        Debug.Log(damage);
        currentHealth -= damage;  // si on prends des degats ont retire de la vie a la vie actuelle
        healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie
        if (currentHealth <= 0)
        {
            Debug.Log("c'est tipar");
            //ResetEnnemyPos();
            Debug.Log(transform.position);
            Debug.Log(respawnPoint);
            transform.position = respawnPoint;
        }
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
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
