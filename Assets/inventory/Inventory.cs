using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int maxSlots = 2;
    public List<InventorySlot> slots = new List<InventorySlot>();

    public Image[] slotBackgrounds;
    public Image[] itemImages;

    public bool hasItem = false;

    private void Awake()
    {
        instance = this;
        InitializeEmptySlots();
    }

    private void InitializeEmptySlots()
    {
        for (int i = 0; i < itemImages.Length; i++)
        {
            itemImages[i].color = new Color(1, 1, 1, 0);
        }
    }

    public bool CanAddItem()
    {
        return slots.Count < maxSlots;
    }

    public void AddItem(Item item)
    {
        if (CanAddItem())
        {
            InventorySlot newSlot = new InventorySlot
            {
                itemName = item.itemName,
                itemIcon = item.itemIcon


            };
            slots.Add(newSlot);
            UpdateUI();
            hasItem = true;


        }
    }

    public void RemoveItem(InventorySlot item) {
        if (!InventoryContainsItem(item.itemName)) return;

        InventorySlot itemToRemove = null;
        foreach (var currentItem in slots)
        {
            if(currentItem.itemName == item.itemName) {
                itemToRemove = currentItem;
                break;
            }
        }
        if (itemToRemove != null)
        {
            slots.Remove(itemToRemove);
        }
    }

    public InventorySlot GetItemByName(string itemName) {
        foreach (var item in slots)
        {
            if (item.itemName == itemName)
                return item;
        }
        return null;
    }


    public bool InventoryContainsItem(string itemName)
   
    {
        foreach (var item in slots)
        {
            if(item.itemName == itemName)
                return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < itemImages.Length; i++)
        {
            if (i < slots.Count && slots[i] != null)
            {
                // Poka¿ ikonê przedmiotu
                itemImages[i].sprite = slots[i].itemIcon;
                itemImages[i].color = Color.white;
            }
            else
            {
                itemImages[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
}


[System.Serializable]
public class InventorySlot
{
    public string itemName;
    public Sprite itemIcon;
}