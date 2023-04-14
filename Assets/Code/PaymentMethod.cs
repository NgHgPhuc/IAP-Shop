using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentMethod : MonoBehaviour
{
    public static PaymentMethod Instance { get; private set; }
    public InventorySystem inventorySystem;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Pay(BundleObject bundleObject)
    {

        switch (bundleObject.cost.costType)
        {
            case Cost.CostType.Money:
                PayInMoney(bundleObject);
                break;
            case Cost.CostType.Coin:
                PayInCoin(bundleObject);
                break;
            case Cost.CostType.Diamond:
                PayInDiamond(bundleObject);
                break;
            case Cost.CostType.Ads:
                PayInAds(bundleObject);
                break;
            default:
                break;

        }

    }
    void PayInMoney(BundleObject bundleObject) //cost nothing but time :D
    {
        GetItem(bundleObject);
    }
    void PayInCoin(BundleObject bundleObject)
    {
        if (!ResourcePanel.Instance.CheckEnough(bundleObject.cost.Mount, ResourcePanel.Instance.CoinMount))
        {
            //Debug Error Log
            return;
        }

        //Minus Cost
        ResourcePanel.Instance.UseCoin(-bundleObject.cost.Mount); //lost coin
        GetItem(bundleObject); // get item from bundle

    }
    void PayInDiamond(BundleObject bundleObject)
    {
        if (!ResourcePanel.Instance.CheckEnough(bundleObject.cost.Mount, ResourcePanel.Instance.DiamondMount))
        {
            //Debug Error Log
            return;
        }

        //Minus Cost
        ResourcePanel.Instance.UseDiamond(-bundleObject.cost.Mount); //lost coin
        GetItem(bundleObject); // get item from bundle

    }

    void PayInAds(BundleObject bundleObject) //cost nothing but time :D
    {
        GetItem(bundleObject);
    }

    //Get item and add to inventory
    void GetItem(BundleObject bundleObject)
    {
        foreach (Slot s in bundleObject.Items)
        {
            switch (s.item.GetItemType())
            {
                case Item.ItemType.ITEM:
                    inventorySystem.InventoryAdd(s);
                    break;
                case Item.ItemType.RESOURCE:
                    if (s.item.GetID() == "Coin")
                        ResourcePanel.Instance.UseCoin(s.Number); //get coin
                    if (s.item.GetID() == "Diamond")
                        ResourcePanel.Instance.UseDiamond(s.Number);
                    break;
                default:
                    break;
            }
        }
    }
}
