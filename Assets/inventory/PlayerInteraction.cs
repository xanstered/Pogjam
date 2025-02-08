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
    public InteractableItem currentInteractable;
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
            InteractableItem item = hit.collider.GetComponent<InteractableItem>();
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
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            if (Inventory.instance.CanAddItem())
            {
                Inventory.instance.AddItem(currentInteractable);
                Destroy(currentInteractable.gameObject);
                currentInteractable = null;
                HideInteractionPrompt();
            }
            else
            {
                Debug.Log("Ekwipunek jest pe³ny!");
            }
        }
    }

    private void ShowInteractionPrompt()
    {
        interactionText.text = "[F] Interact";
        interactionText.gameObject.SetActive(true);
    }

    private void HideInteractionPrompt()
    {
        interactionText.gameObject.SetActive(false);
    }
}