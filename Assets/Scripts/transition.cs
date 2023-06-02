using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public Animator screen;
    public float wait_time;

    /*public IEnumerator ChangeScene()
    {
        screen.SetTrigger("End");
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("CREDITS");
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
