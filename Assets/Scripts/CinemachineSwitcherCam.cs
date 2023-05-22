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
    public bool playMusic;

    private void Start()
    {
        disasterpiece = GetComponent<AudioSource>();
        karen3 = GetComponent<AudioSource>();
        playMusic = true;
    }
    private void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (debut && playMusic == true)
            {
                animator.SetBool("Debut", true);
                disasterpiece.Play();
            }
            if (trone)
            {
                animator.SetBool("Trone", true);
            }
            if (proche)
            {
                animator.SetBool("Proche", true);
                spotlight.SetActive(true);
            }
            if (fin && playMusic == true)
            {
                karen3.Play();
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (debut && playMusic == false)
            {
                animator.SetBool("Debut", false);
                disasterpiece.Stop();
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
            }
            if (fin && playMusic == false)
            {
                karen3.Stop();
            }
        }
    }
}
