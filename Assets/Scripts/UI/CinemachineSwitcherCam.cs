using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CinemachineSwitcherCam : MonoBehaviour
{
    [SerializeField] bool debut;
    [SerializeField] bool trone;
    [SerializeField] bool proche;
    [SerializeField] bool fin;
    [SerializeField] Animator animator;
    public GameObject spotlight;
    public GameObject globalLight;
    public AudioSource disasterpiece;
    public AudioSource karen3;
    public AudioSource SubwaySurfers;
    public AudioSource ClericBeast;

    private void Start()
    {

    }
    private void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (debut)
            {
                animator.SetBool("Debut", true);
                SubwaySurfers.Play();
                Debug.Log("Subway Surfers Music now playing");
            }
            if (trone)
            {
                animator.SetBool("Trone", true);
                ClericBeast.Play();
                Debug.Log("Bloodborne Music now playing");
            }
            if (proche)
            {
                animator.SetBool("Proche", true);
                spotlight.SetActive(true);
                globalLight.SetActive(true);
                disasterpiece.Play();
                Debug.Log("Detroit by Disasterpiece now playing");
            }
            if (fin)
            {
                animator.SetBool("Fin", true);
                karen3.Play();
                Debug.Log("Karen3 by Smaland now playing");
                Destroy(GameObject.FindWithTag("Astaroth"));
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (debut)
            {
                animator.SetBool("Debut", false);
                SubwaySurfers.Stop();
            }
            if (trone)
            {
                animator.SetBool("Trone", false);
                ClericBeast.Stop();
            }
            if (proche)
            {
                animator.SetBool("Proche", false);
                spotlight.SetActive(false);
                globalLight.SetActive(false);
                disasterpiece.Stop();
            }
            if (fin)
            {
                animator.SetBool("Fin", false);
            }
        }
    }
}
