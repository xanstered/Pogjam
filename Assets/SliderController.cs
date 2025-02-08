using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
     public Slider NoiseSlider;
    public float fillAmount = 1f;
    public float maxAmount = 100f;
   


   void Start()
    {
        NoiseSlider.value = 0;
    }

    public void FillSlider()
    {
        NoiseSlider.value += fillAmount;

        if ( NoiseSlider.value > maxAmount)
        {
            NoiseSlider.value = maxAmount;
        }
    }

}
