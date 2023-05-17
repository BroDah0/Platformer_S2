using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CinemachineSwitcherCam : MonoBehaviour
{
    [SerializeField] bool debut;
    [SerializeField] bool trone;
    [SerializeField] bool proche;
    [SerializeField] Animator animator;
    public Light pointlight;
    LightFollowPlayer Light;

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
                Light light = Instantiate(pointlight, transform.position, transform.rotation);
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
            }
        }
    }
}
