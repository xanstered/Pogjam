using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemIcon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteraction.instance.currentInteractable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerInteraction.instance.currentInteractable == this)
            {
                PlayerInteraction.instance.currentInteractable = null;
            }
        }
    }
}
