using System.Collections;
using System.Collections.Generic;
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
}
