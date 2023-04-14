using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Dictionary<string, Slot> inventory = new Dictionary<string, Slot>();
    float MaxStack = 10;
    float MaxSlot = 30;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InventoryAdd(Slot AddSlot)
    {
        Slot s = new Slot(AddSlot);
        string nameItem = s.ItemNameInSlot();
        if (inventory.ContainsKey(nameItem))
            inventory[nameItem].Number += s.Number;
        else inventory.Add(nameItem, s);
    }

    public void InventoryDrop(string SlotName)
    {
        if (inventory.ContainsKey(SlotName))
        {
            inventory[SlotName].Number--;
            if (inventory[SlotName].Number <= 0)
                inventory.Remove(SlotName);
        }
    }
}
