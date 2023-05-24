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
    public Light globalLight;
    public AudioSource disasterpiece;
    public AudioSource karen3;

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
            }
            if (trone)
            {
                animator.SetBool("Trone", true);
            }
            if (proche)
            {
                animator.SetBool("Proche", true);
                spotlight.SetActive(true);
                disasterpiece.Play();
                Debug.Log("Detroit by Disasterpiece now playing");
            }
            if (fin)
            {
                animator.SetBool("Fin", true);
                karen3.Play();
                Debug.Log("Karen3 by Smaland now playing");
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
            }
            if (trone)
            {
                animator.SetBool("Trone", false);
            }
            if (proche)
            {
                animator.SetBool("Proche", false);
                GameObject.Destroy(spotlight);
                GameObject.Destroy(globalLight);
                disasterpiece.Stop();
            }
            if (fin)
            {
                animator.SetBool("Fin", false);
            }
        }
    }
}
