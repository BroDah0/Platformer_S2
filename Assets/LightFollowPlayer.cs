using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    PointLight pointlight;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gameObject.transform.SetParent(player.transform);
        pointlight = GetComponent<PointLight>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
