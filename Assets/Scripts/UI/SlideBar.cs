using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlideBar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    public void SetSlide(int slide)
    {
        slider.value = slide;
    }

    public IEnumerator SlideCooldown()
    {
        for (int i = 0; i <= 7; i++)
        {
            SetSlide(i);
            yield return new WaitForSeconds(1);
        }
    }
}
