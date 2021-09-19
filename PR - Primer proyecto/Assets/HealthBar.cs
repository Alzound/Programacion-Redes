using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slide;
    public Gradient grad;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slide.maxValue = health;
        slide.value = health;

        fill.color = grad.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slide.value = health;
        fill.color = grad.Evaluate(slide.normalizedValue);

    }

   
}
