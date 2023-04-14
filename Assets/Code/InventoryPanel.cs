using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SlotPanel;
    public Transform InfoPanel;
    public InventorySystem inventorySystem;

    string NameSlotChosing;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSlotUI(Transform slotUI,Slot slot)
    {
        slotUI.Find("Icon").GetComponent<Image>().sprite = slot.item.GetIcon();
        slotUI.Find("Count").GetComponent<TextMeshProUGUI>().SetText(slot.Number.ToString());
    }

    void UpdateInventoryUI()
    {
        foreach(Transform SlotUI in SlotPanel)
        {
            SlotUI.gameObject.SetActive(false);
        }

        int i = 0;
        foreach(KeyValuePair<string,Slot> s in inventorySystem.inventory)
        {
            SlotPanel.GetChild(i).gameObject.SetActive(true);
            SetSlotUI(SlotPanel.GetChild(i), s.Value);
            i++;
        }
    }

    public void OpenInventoryUI()
    {
        SoundManager.Instance.SoundFxPlay(SoundManager.Instance.Open);
        UpdateInventoryUI();
        gameObject.SetActive(true);
        animator.Play("Open");
        InfoPanel.Find("Icon").GetComponent<Image>().sprite = null;
        InfoPanel.Find("Name").GetComponent<TextMeshProUGUI>().SetText("???");

    }
    public void ClickBackground()
    {
        SoundManager.Instance.SoundFxPlay(SoundManager.Instance.Close);
        animator.Play("Close");
    }
    public void CloseInventoryUI()
    {
        gameObject.SetActive(false);
    }


    public void SetInfoPanel(Transform slotUI)
    {
        SoundManager.Instance.PlayMeow();
        NameSlotChosing = slotUI.Find("Icon").GetComponent<Image>().sprite.name;
        InfoPanel.Find("Icon").GetComponent<Image>().sprite = slotUI.Find("Icon").GetComponent<Image>().sprite;
        InfoPanel.Find("Name").GetComponent<TextMeshProUGUI>().SetText(NameSlotChosing);
    }

    public void DropButton()
    {
        SoundManager.Instance.SoundFxPlay(SoundManager.Instance.Drop);
        inventorySystem.InventoryDrop(NameSlotChosing);
        UpdateInventoryUI();
    }
}
