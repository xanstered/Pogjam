using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    public bool isNearDoor = false;
    public bool isNearBoards = false;
    public bool isNearFridge = false;
    public SliderController controller;
    public GameObject k�odka;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boards")) 
        {
            Debug.Log("Gracz dotkn�� skrzypi�cych desek");
            isNearBoards=true;
            controller.FillSlider();

            
        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("dotkn�� drzwi");
            isNearDoor = true;
        }

        if (other.CompareTag("T"))
        {
            Debug.Log("blisko lod�wki");
            isNearFridge=true;
            
        }
    }

    private void TrigerK��dka()
    {
        Destroy(k�odka);
    }
   

    private void Update()
    {
        if (isNearFridge)
        {
            
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("klika F");
                TrigerK��dka();
            }
        }
       
    }
}
