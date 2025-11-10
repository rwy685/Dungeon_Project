using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quantityText;

    private ItemData currentItem;

    public void SetItem(ItemData item)
    {
        currentItem = item;
        icon.sprite = item.icon;
        icon.enabled = true;
        quantityText.text = "1";
    }

    public void ClearSlot()
    {
        currentItem = null;
        icon.enabled = false;
        quantityText.text = "";
    }
}
