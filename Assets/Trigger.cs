using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    public bool isNearDoor = false;
    public bool isNearBoards = false;
    public bool isNearFridge = false;
    public SliderController controller;
    public GameObject k這dka;
    public DoorSlider doorSlider;
    public string neededItem;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boards")) 
        {
            Debug.Log("Gracz dotkn像 skrzypi鉍ych desek");
            isNearBoards=true;
            controller.FillSlider();

            
        }

        else if (other.CompareTag("Door"))
        {
            Debug.Log("dotkn像 drzwi");
            isNearDoor = true;
            doorSlider.slider.SetActive(true);
            
           
            
        }
      

        else if (other.CompareTag("T"))
        {
            Debug.Log("blisko lod闚ki");
            isNearFridge=true;
            
        }
    }

    private void TrigerK堯dka()
    {
        Destroy(k這dka);
    }

   
   

    private void Update()
    {
        if (isNearFridge)
        {

            if (Inventory.instance.InventoryContainsItem(neededItem))
            {

                if (Input.GetKey(KeyCode.F))
                {
                    Debug.Log("klika F");
                    TrigerK堯dka();
                }
            }
            
        }
        if (isNearDoor)
        {
            doorSlider.FillDoor();

        }
    }

   
}
