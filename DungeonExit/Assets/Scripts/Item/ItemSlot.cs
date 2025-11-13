using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI quantityText;

    public ItemData currentItem;
    public int quantity; 

    //아이템 습득시 슬롯세팅
    public void SetItem(ItemData item)
    {
        currentItem = item;
        icon.sprite = item.icon;
        icon.enabled = true;
        quantity = 1;
        quantityText.text = quantity.ToString();
    }

    //아이템 중복시 수량만 늘리기
    public void AddQuantity(int amount)
    {
        quantity += amount;
        quantityText.text = quantity.ToString();
    }

    //아이템 없으면 슬롯 비우기
    public void ClearSlot()
    {
        if (icon.sprite != null)
        {
            currentItem = null;
            quantity = 0;
            icon.enabled = false;
            quantityText.text = "";
        }
    }
}
