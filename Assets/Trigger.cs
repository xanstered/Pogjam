using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{
    public static Trigger instance;
    public bool isNearDoor = false;
    public bool isNearBoards = false;
    public bool isNearFridge = false;
    public bool isNoise=false;
    public SliderController controller;
    
   
    public DoorSlider doorSlider;
   
   

    public TextMeshProUGUI text;
    public Coroutine dogNoise;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        text.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boards")) 
        {
            Debug.Log("Gracz dotkn�� skrzypi�cych desek");
            isNearBoards=true;
            controller.FillSlider();

            
        }

        else if (other.CompareTag("Door"))
        {
            Debug.Log("dotkn�� drzwi");
            isNearDoor = true;
            doorSlider.slider.SetActive(true);
            
           
            
        }


       else if (other.CompareTag("triggerDog"))
        {
            Debug.Log("start");
           dogNoise= StartCoroutine(DogNoise());
            
            text.enabled = true;
            text.text = "Feed the dog,Find food";


           
        }
    }

    public void StopDogNoise()
    {
        StopCoroutine(dogNoise);
    }

   public IEnumerator DogNoise()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Debug.Log("g�os szczekania");
            text.enabled = false;
            isNoise = true;

            controller.FillSlider();


        }


        
    
    }

   

   
    
   
   

    private void Update()
    {
       
        if (isNearDoor)
        {
            doorSlider.FillDoor();

        }
       
       
    }

   
}
