using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
     public Slider NoiseSlider;
    public float fillAmount = 1f;
    public float maxAmount = 100f;
    public bool isCharging = false;
   [SerializeField] private GameObject LosePanel;
   


   void Start()
    {
        NoiseSlider.value = 0;
        LosePanel.SetActive(false);
    }

    
    public void Update()
    {
        if (isCharging && NoiseSlider.value < maxAmount) 
        {
            NoiseSlider.value += fillAmount * Time.deltaTime;
        }
        if (NoiseSlider.value >= maxAmount)
        {
            NoiseSlider.value = maxAmount;
            LosePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    public void StartCharging()
    {
        isCharging=true;
        if (NoiseSlider.value > maxAmount)
        {
            NoiseSlider.value = maxAmount;
            LosePanel.SetActive(true);

        }
    }
    public void StopCharging()
    {
        isCharging=false;
    }

    public void InstantCharge()
    {
        NoiseSlider.value += fillAmount;
        
    }

}
