using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public float CoinMount;
    public float DiamondMount;
    string CoinTextShow;
    string DiamondTextShow;

    [SerializeField] TextMeshProUGUI CoinTMP;
    [SerializeField] TextMeshProUGUI DiamondTMP;
    public GameObject flowResource;

    public static ResourcePanel Instance { get; private set; }

    private void Awake()
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

    void Start()
    {
        ReloadResourceShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadResourceShow()
    {
        CoinTextShow = "x" + CoinMount;
        CoinTMP.SetText(CoinTextShow);
        DiamondTextShow = "x" + DiamondMount;
        DiamondTMP.SetText(DiamondTextShow);
    }
    //COIN
    public bool CheckEnough(float Need,float Have)
    {
        if (Need > Have)
            return false;
        return true;
    }
    public void UseCoin(float mount)
    {
        CoinMount += mount;
        CoinTextShow = "x" + CoinMount;
        CoinTMP.SetText(CoinTextShow);
        if(mount > 0)
        {
            GameObject Clone = Instantiate(flowResource, transform.GetChild(0));
            Clone.GetComponent<FlowResource>().GetResource(mount);
        }
        else
        {
            GameObject Clone = Instantiate(flowResource, transform.GetChild(0));
            Clone.GetComponent<FlowResource>().DropResource(mount);
        }
    }

    public void UseDiamond(float mount)
    {
        DiamondMount += mount;
        DiamondTextShow = "x" + DiamondMount;
        DiamondTMP.SetText(DiamondTextShow);
        if (mount > 0)
        {
            GameObject Clone = Instantiate(flowResource, transform.GetChild(1));
            Clone.GetComponent<FlowResource>().GetResource(mount);
        }
        else
        {
            GameObject Clone = Instantiate(flowResource, transform.GetChild(1));
            Clone.GetComponent<FlowResource>().DropResource(mount);
        }
    }
}
