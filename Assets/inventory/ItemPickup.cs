using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Podstawowe ustawienia")]
    [SerializeField] private float pickupRange = 3f;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private Vector3 heldItemPosition = new Vector3(0, -0.5f, 2f);

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI promptText;

    private GameObject currentItem;
    private GameObject heldItem;

    private void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (heldItem == null)
        {
            CheckForInteractable();
        }
        else
        {

            if (promptText != null)
            {
                promptText.text = $"[G] Drop: " + heldItem.name;
                promptText.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                DropItem();
            }
        }
    }

    private void CheckForInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange))
        {
            // Sprawdzanie przedmiotu do podniesienia
            if (hit.collider.CompareTag("Pickupable"))
            {
                if (promptText != null)
                {
                    promptText.text = "[F] Pick up";
                    promptText.gameObject.SetActive(true);
                }

                currentItem = hit.collider.gameObject;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    PickupItem();
                }
            }

            else
            {
                if (promptText != null)
                {
                    promptText.gameObject.SetActive(false);
                }
                currentItem = null;
            }
        }
        else
        {
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
            currentItem = null;
        }
    }

    private void PickupItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SetParent(itemHolder);
            currentItem.transform.localPosition = heldItemPosition;
            currentItem.transform.localRotation = Quaternion.identity;

            if (currentItem.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            if (currentItem.TryGetComponent<Collider>(out Collider collider))
            {
                collider.enabled = false;
            }

            heldItem = currentItem;


            currentItem = null;
        }
    }


    private void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null);

            if (heldItem.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddForce(Camera.main.transform.forward * 5f, ForceMode.Impulse);
            }

            if (heldItem.TryGetComponent<Collider>(out Collider collider))
            {
                collider.enabled = true;
            }

            heldItem = null;

            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }

}