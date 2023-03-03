using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
   /*public bool is_sliding = false;

   Player player;

   Rigidbody2D rb;

   Animator animController;

   BoxCollider2d normalColl;
   BoxCollider2d slideColl;

   [SerializeField] public float SlideSpeed = 500.0f;

   private void Update()
   {
        if (Input.GetKeyDown(KeyCode.A))
        {
            preformSlide();
        }
   }

   private void preformSlide()
   {
        is_sliding = true;

        animController.SetBool ("IsSlide",  true);

        normalColl.enabled = false;
        slideColl.enabled = true;

        if (!Player.sprite.flipX)

        {
            rb.AddForce (Vector2.right * SlideSpeed);
        }

        else
        {
            rb.AddForce (Vector2.left * SlideSpeed);
        }

        StartCoroutine ("StopSlide");
   }

   IEnumerator StopSlide()
   {
        yield return new WaitForSeconds (0.8f);
        animController.Play ("Idle");
        animController.SetBool ("IsSlide", false);
        normalColl.enabled = true;
        slideColl.enabled = false;
        is_sliding = true;
   }*/

}
