using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    public float interactionDistance = 2f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI interactionText;
    public IInteractable currentInteractable;
    public Camera playerCamera;
   

    private void Awake()
    {
        instance = this;
        interactionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
        HandleInteraction();
    }

    private void CheckForInteractable()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable item = hit.collider.GetComponent<IInteractable>();
            if (item != null)
            {
                currentInteractable = item;
                ShowInteractionPrompt();
            }
        }
        else
        {
            currentInteractable = null;
            HideInteractionPrompt();
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null && currentInteractable is Item)
        {
            var currentItem = currentInteractable as Item;
            if (Inventory.instance.CanAddItem())
            {
                Inventory.instance.AddItem(currentItem);
                Destroy(currentItem.gameObject);
                currentInteractable = null;
                HideInteractionPrompt();
            }
            else
            {
                Debug.Log("Ekwipunek jest pe³ny!");
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null && currentInteractable is InteractableItem)
        {
            var currentInteractableItem = currentInteractable as InteractableItem;
            currentInteractableItem.Interact();
            Inventory.instance.RemoveItem(Inventory.instance.GetItemByName(currentInteractableItem.itemName));
        }

    }

    public void ShowInteractionPrompt()
    {
        interactionText.gameObject.SetActive(true);
        if (currentInteractable is Item) {
            interactionText.text = "[F] Interact";
            return; 
        }

        var currrentInteract = currentInteractable as InteractableItem;
        if (!Inventory.instance.InventoryContainsItem(currrentInteract.itemName))
        {
            interactionText.text = "You don't have necessary item!";
            return;
        }
            interactionText.text = "[F] Interact";
    }

    private void HideInteractionPrompt()
    {
        interactionText.gameObject.SetActive(false);
    }
}