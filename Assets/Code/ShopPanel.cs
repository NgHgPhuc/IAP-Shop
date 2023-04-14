using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
        animator.Play("Open");

    }
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
    public void ClickBackground()
    {
        animator.Play("Close");
    }
}
