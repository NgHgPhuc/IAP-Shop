using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public AdsInitializer adsInitializer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        SoundManager.Instance.SoundFxPlay(SoundManager.Instance.Open);
        gameObject.SetActive(true);
        animator.Play("Open");
        adsInitializer.LoadAd();

    }
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
    public void ClickBackground()
    {
        SoundManager.Instance.SoundFxPlay(SoundManager.Instance.Close);
        animator.Play("Close");
    }
}
