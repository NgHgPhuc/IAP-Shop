using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [Serializable]
    public enum ItemType
    {
        ITEM,
        RESOURCE
    }
    [SerializeField] ItemType itemType;
    [SerializeField] string ID;
    [SerializeField] string Name;
    [SerializeField] Sprite Icon;

    public string GetID()
    {
        return ID;
    }
    public string GetName()
    {
        return Name;
    }
    public Sprite GetIcon()
    {
        return Icon;
    }
    public ItemType GetItemType()
    {
        return itemType;
    }

}
