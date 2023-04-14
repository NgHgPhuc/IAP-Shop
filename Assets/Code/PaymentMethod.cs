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

                break;
            case Cost.CostType.Coin:
                PayInCoin(bundleObject);
                break;
            case Cost.CostType.Diamond:

                break;
            case Cost.CostType.Ads:

                break;
            default:
                break;

        }

    }

    void PayInCoin(BundleObject bundleObject)
    {
        if(!ResourcePanel.Instance.CheckEnoughCoin(bundleObject.cost.Mount))
        {
            //Debug Error Log
            return;
        }

        //Minus Cost
        ResourcePanel.Instance.UseCoin(-bundleObject.cost.Mount); //lost coin
        foreach(Slot s in bundleObject.Items)
        {
            switch(s.item.GetItemType())
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
