using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Cost
{
    [Serializable]
    public enum CostType
    {
        Money,
        Coin,
        Diamond,
        Ads
    }
    public CostType costType;
    public float Mount;

}
