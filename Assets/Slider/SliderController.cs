using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
     public Slider NoiseSlider;
    public float fillAmount = 1f;
    public float maxAmount = 100f;
   [SerializeField] private GameObject LosePanel;
   


   void Start()
    {
        NoiseSlider.value = 0;
        LosePanel.SetActive(false);
    }

    public void FillSlider()
    {
        NoiseSlider.value += fillAmount;

        if ( NoiseSlider.value > maxAmount)
        {
            NoiseSlider.value = maxAmount;
            LosePanel.SetActive(true);

        }
    }

}
