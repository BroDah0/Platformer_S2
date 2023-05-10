using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float coordonnee;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
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
        Debug.Log("cum");
        Debug.Log(damage);
        currentHealth -= damage;  // si on prends des degats ont retire de la vie a la vie actuelle
        healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie  
    }
}
