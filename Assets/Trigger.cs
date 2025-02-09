
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
    public bool isDogFed = false;
    private bool canTriggerDog = true;
    public SliderController controller;

    public GameObject trigerWasch;
    public DoorSlider doorSlider;
   
   

    public TextMeshProUGUI text;
    public Coroutine dogNoise;
    private bool isNearDog = false;

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
            AudioManager.Instance.Play(AudioManager.SoundType.FloorSqueak);


        }

        else if (other.CompareTag("Door"))
        {
            Debug.Log("dotkn¹³ drzwi");
            text.enabled = false;
            text.text = "Press [J] on image to open door quietly";
            isNearDoor = true;
            doorSlider.slider.SetActive(true);
            AudioManager.Instance.Play(AudioManager.SoundType.OpenDoor);
            text.enabled = true;



        }

        else if (other.CompareTag("triggerDog") && canTriggerDog && !isDogFed)
        {
            Debug.Log("start");
            isNearDog = true;
            dogNoise = StartCoroutine(DogNoise());
            UpdateDogText();
        }
        else if (other.CompareTag("wasch"))
        {
            Debug.Log("pralka");
            isNoise = false;
            AudioManager.Instance.Stop(AudioManager.SoundType.WashingMachine);
            trigerWasch.SetActive(false); // Dezaktywujemy trigger, ¿eby nie mo¿na by³o ponownie uruchomiæ
        }
        else if (other.CompareTag("waschtrigger"))
        {
            Debug.Log("dŸwiêk pralki");
            text.enabled = false;
            text.text = "[G] to turn off washine maschine";
            if (!isNoise) // Sprawdzamy czy dŸwiêk nie jest ju¿ odtwarzany
            {
                AudioManager.Instance.Play(AudioManager.SoundType.WashingMachine);
                isNoise = true;
                controller.StartCharging();
                trigerWasch.SetActive(false);
                text.enabled = true;
            }
        }
    }



    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("triggerDog"))
        {
            isNearDog = false;
            text.enabled = false;
        }
    }

    private void UpdateDogText()
    {
        if (!isDogFed)
        {
            if (Inventory.instance.InventoryContainsItem("DogFood"))
            {
                text.enabled = true;
                text.text = "[F] Feed";
            }
            else
            {
                text.enabled = true;
                text.text = "Feed the dog, Find food";
            }
        }
    }

    public void StopDogNoise()
    {
        if (dogNoise != null)
        {
            StopCoroutine(dogNoise);
            dogNoise = null;
        }
    }

    public IEnumerator DogNoise()
    {
        while (!isDogFed)
        {
            yield return new WaitForSeconds(3); // Zmienione na 5 sekund
            Debug.Log("g³os szczekania");
            if (!isDogFed)
            {
                controller.InstantCharge();
                AudioManager.Instance.Play(AudioManager.SoundType.Bark);
            }
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

        // Obs³uga karmienia psa
        if (isNearDog && !isDogFed && Input.GetKeyDown(KeyCode.F) && Inventory.instance.InventoryContainsItem("DogFood"))
        {
            isDogFed = true;
            canTriggerDog = false; // Blokujemy mo¿liwoœæ ponownego wywo³ania triggera
            StopDogNoise();
            text.enabled = false;
            // Usuñ karmê z ekwipunku
            Inventory.instance.RemoveItem(Inventory.instance.GetItemByName("DogFood"));
            Debug.Log("Dog has been fed!");
        }
    }
}