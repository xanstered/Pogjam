using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
     public Slider NoiseSlider;
    public float fillAmount = 1f;
    public float maxAmount = 100f;
    public bool isCharging = false;
   
   


   void Start()
    {
        NoiseSlider.value = 0;
        
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
        if (NoiseSlider.value >= maxAmount)
        {
            NoiseSlider.value = maxAmount;
            SceneManager.LoadScene("YouLose");
            

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
