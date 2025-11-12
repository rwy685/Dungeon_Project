using System.Collections.Generic;
using UnityEngine;
public class UIInventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public ItemSlot[] itemSlots;

    public void AddItem(ItemData newItem)
    {
        if (items.Count >= itemSlots.Length)
            return;
        items.Add(newItem);
        UpdateUI();
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= items.Count)
            return;

        ItemData item = items[index];
        ApplyItemEffect(item);
        items[index] = null;
        UpdateUI();
    }

    void ApplyItemEffect(ItemData item)
    {
        if (item.type == ItemType.Consumable)
        {
            foreach (var c in item.consumables)
            {
                if (c.Type == ConsumableType.Health)
                    CharacterManager.Instance.Player.condition.Heal(c.value);
                else if (c.Type == ConsumableType.JumpBoost)
                    CharacterManager.Instance.Player.controller.BoostJump(c.value);
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log($"[UIInventory] UpdateUI 실행됨, items.Count = {items.Count}");
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < items.Count && items[i] != null)
            {
                Debug.Log($"슬롯 {i}에 {items[i].displayName} 설정");
                itemSlots[i].SetItem(items[i]);
            }
            else
                itemSlots[i].ClearSlot();
        }
    }
}
