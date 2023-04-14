using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowResource : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        Destroy(gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetResource(float value)
    {
        animator.Play("Flow Up");
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText("+"+value);
    }
    public void DropResource(float value)
    {
        animator.Play("Flow Down");
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(value.ToString());
    }
}
