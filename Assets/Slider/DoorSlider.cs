using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSlider : MonoBehaviour
{
    public Slider Door;
   private float speed =10f;
    private float min = 0f;
    private float max = 100;
    public RectTransform handleRect;
    public RectTransform backgroundRect;
    public RectTransform imageRect;
    public GameObject slider;

    public SliderController sliderController;


    public bool increasing = false;
    public bool wrong = false;
    public bool check = false;
    private void Start()
    {

        Door.value = 0;
        
        slider.SetActive(false);
    }

    public void FillDoor()
    {
        
        if (increasing)
        {
            Door.value += speed * Time.deltaTime;
            if (Door.value >= max)
                increasing = false;
        }
        else
        {
            Door.value -= speed * Time.deltaTime;
            if (Door.value <= min)
                increasing = true;
        }
       

    }
    public void Update()
    {
       
        
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (IsHandleOverUIElement(imageRect))
                {
                    Debug.Log("image");
                slider.gameObject.SetActive(false);
                Door.value = 0;
                increasing = false;
               
                }
                else if (IsHandleOverUIElement(backgroundRect))
                {
                    Debug.Log("background");
                slider.gameObject.SetActive(false);
                Door.value = 0;
                increasing = false;
                sliderController.InstantCharge();
                
               
                
                

                }
            }
        
    }
   



   
    bool IsHandleOverUIElement(RectTransform uiElement)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(uiElement, handleRect.position);
    }

}
