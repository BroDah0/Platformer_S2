using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcherCam : MonoBehaviour
{
    [SerializeField] bool debut;
    [SerializeField] bool trone;
    [SerializeField] bool proche;
    [SerializeField] Animator animator;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(debut)
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
