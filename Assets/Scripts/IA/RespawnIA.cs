using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnIA : MonoBehaviour
{
    public Transform respawnPoint;

    [SerializeField] PlayerHealth playerhealth;
    
    void Start()
    {
        transform.position = respawnPoint.position;
    }

    
    void Update()
    {
        
    }
}
