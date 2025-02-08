using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour, IInteractable
{
    public string itemName;
    public Sprite itemIcon;

    public UnityEvent onInteract;

    public void Interact() {
        onInteract.Invoke();
    }
}
