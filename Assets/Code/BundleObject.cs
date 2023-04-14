using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BundleObject : MonoBehaviour
{
    public List<Slot> Items;
    public Cost cost;

    public Button BuyButton;
    public bool PayInGame;
    void Start()
    {
        if(PayInGame)
            BuyButton.onClick.AddListener(delegate { PaymentMethod.Instance.Pay(this);});
    }
}
