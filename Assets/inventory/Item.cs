using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable {
    public string itemName;
    public Sprite itemIcon;

    public void Interact()    {
        PickupItem();
    }

    /*private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            PickupItem();
    }*/

    private void PickupItem() {
        Inventory.instance.AddItem(this);
        Destroy(gameObject);
    }
}
