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

    public GameObject trigerWasch;
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
            Debug.Log("Gracz dotkn¹³ skrzypi¹cych desek");
            isNearBoards = true;
            controller.InstantCharge();


        }

        else if (other.CompareTag("Door"))
        {
            Debug.Log("dotkn¹³ drzwi");
            isNearDoor = true;
            doorSlider.slider.SetActive(true);



        }


        else if (other.CompareTag("triggerDog"))
        {
            Debug.Log("start");
            dogNoise = StartCoroutine(DogNoise());

            text.enabled = true;
            text.text = "Feed the dog,Find food";



        }

        else if (other.CompareTag("wasch"))
        {
            Debug.Log("pralka");
            isNoise = false;
           
        }

        else if (other.CompareTag("waschtrigger"))
        {
            Debug.Log("dŸwiêk pralki");
            isNoise = true;
            if (isNoise)
            {
               controller.StartCharging();
            }
            trigerWasch.SetActive(false);
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
            Debug.Log("g³os szczekania");
            text.enabled = false;
            controller.InstantCharge();
           
            


        }


        
    
    }

   

   
    
   
   

    private void Update()
    {
       
        if (isNearDoor)
        {
            doorSlider.FillDoor();

        }

        if (!isNoise && Input.GetKeyDown(KeyCode.G))
        {
            controller.StopCharging();
        }

        
    }


   
}
