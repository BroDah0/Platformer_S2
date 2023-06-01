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
    public GameObject squareLight;
    public AudioSource horrormusic;
    public AudioSource karen3;
    public AudioSource EpicMusic;
    public AudioSource Astarothmusic;

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
                EpicMusic.Play();
                Debug.Log("Epic Music now playing");
            }
            if (trone)
            {
                animator.SetBool("Trone", true);
                Astarothmusic.Play();
                Debug.Log("Majestuous Music now playing");
            }
            if (proche)
            {
                animator.SetBool("Proche", true);
                spotlight.SetActive(true);
                globalLight.SetActive(true);
                squareLight.SetActive(true);
                horrormusic.Play();
                Debug.Log("Horror music now playing");
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
                EpicMusic.Stop();
            }
            if (trone)
            {
                animator.SetBool("Trone", false);
                Astarothmusic.Stop();
            }
            if (proche)
            {
                animator.SetBool("Proche", false);
                spotlight.SetActive(false);
                globalLight.SetActive(false);
                squareLight.SetActive(false);
                horrormusic.Stop();
            }
            if (fin)
            {
                animator.SetBool("Fin", false);
                karen3.Stop();

            }
        }
    }
}
