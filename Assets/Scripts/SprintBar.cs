using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    public void SetSprint (int sprint)
    {
        slider.value = sprint;
    }
}
