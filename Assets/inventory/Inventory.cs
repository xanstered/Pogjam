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

    public void AddItem(InteractableItem item)
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
        }
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