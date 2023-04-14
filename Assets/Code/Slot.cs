using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Slot
{
    public Item item;
    public int Number;

    public string ItemNameInSlot()
    {
        return item.GetName();
    }

    public Slot(Slot s)
    {
        item = s.item;
        Number = s.Number;
    }
    public Slot(Item item,int Number)
    {
        this.item = item;
        this.Number = Number;
    }
}

