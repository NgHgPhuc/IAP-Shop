using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public InventorySystem inventory;

    public Dictionary<string, Item> ItemsData = new Dictionary<string, Item>();

    private void Awake()
    {
        ItemListData();
    }
    void Start()
    {
        LoadInventory();
        LoadResource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ItemListData()
    {
        Item[] items = Resources.LoadAll<Item>("");
        foreach (Item i in items)
        {
            string Key = i.GetName();
            if (!ItemsData.ContainsKey(Key))
            {
                ItemsData.Add(Key, i);
            }
        }
    }

    public void SaveInventory()
    {
        string path = Application.persistentDataPath + "/PlayerData.txt";
        if (!File.Exists(path))
            File.Create(path);

        string InventoryData = "";
        foreach (KeyValuePair<string,Slot> slot in inventory.inventory)
        {
            InventoryData += slot.Key + "_" + slot.Value.Number + "\n";
        }

        File.WriteAllText(path, InventoryData);
    }

    public void LoadInventory()
    {
        string path = Application.persistentDataPath + "/PlayerData.txt";
        if (!File.Exists(path))
            return;

        StreamReader sr = new StreamReader(path);

        //if (Line == "") return;
        string Line = sr.ReadLine();
        while (Line != null && Line != "")
        {
            string itemID = Line.Split("_")[0];
            int Number = int.Parse(Line.Split("_")[1]);

            Slot s = new Slot((Item)ItemsData[itemID],Number);
            inventory.InventoryAdd(s);
            Line = sr.ReadLine();

        }
        sr.Close();
    }

    public void SaveResource()
    {
        try
        {
            string path = Application.persistentDataPath + "/PlayerResource.txt";
            if (!File.Exists(path))
                File.Create(path);

            string ResourceData = ResourcePanel.Instance.CoinMount.ToString() + "_" + ResourcePanel.Instance.DiamondMount.ToString();

            File.WriteAllText(path, ResourceData);
        }
        catch (Exception) { Debug.Log("Error at Save Resource"); }
    }

    public void LoadResource()
    {
        try
        {
            string path = Application.persistentDataPath + "/PlayerResource.txt";
            if (!File.Exists(path))
                return;

            StreamReader sr = new StreamReader(path);

            string Line = sr.ReadLine();
            float CoinMount = float.Parse(Line.Split("_")[0]);
            float DiamondMount = float.Parse(Line.Split("_")[1]);
            ResourcePanel.Instance.CoinMount = CoinMount;
            ResourcePanel.Instance.DiamondMount = DiamondMount;
            ResourcePanel.Instance.ReloadResourceShow();
            sr.Close();
        }
        catch (Exception) { Debug.Log("Error at Load Resource"); }
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
        SaveResource();
    }
}
