using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSprite : MonoBehaviour
{
    public GameObject blockFond;
    public GameObject blockSol;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blockFond.SetActive(true);
        blockSol.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        blockFond.SetActive(false);
        blockSol.SetActive(false);
    }

}
