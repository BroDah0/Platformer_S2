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

    public IEnumerator SprintCooldown()
    {
        for (int i = 0; i <= 10; i++)
        {
            SetSprint(i);
            yield return new WaitForSeconds(1);
        }
    }
}
