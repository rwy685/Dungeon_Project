using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public ItemSlot[] itemSlots;

    public void AddItem(ItemData newItem)
    {
        Debug.Log($"[UIInventory] AddItem 호출됨: {newItem.displayName}");
        if (items.Count >= itemSlots.Length)
            return;
        items.Add(newItem);
        Debug.Log($"현재 인벤토리 아이템 수: {items.Count}");
        Debug.Log($"아이템 추가됨: {newItem.displayName}");
        UpdateUI();
        
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= items.Count)
            return;

        ItemData item = items[index];
        ApplyItemEffect(item);
        items.RemoveAt(index);
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
                else if (c.Type == ConsumableType.JumpingPower)
                    CharacterManager.Instance.Player.controller.BoostJump(c.value);
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log($"[UIInventory] UpdateUI 실행됨, items.Count = {items.Count}");
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < items.Count)
            {
                Debug.Log($"슬롯 {i}에 {items[i].displayName} 설정");
                itemSlots[i].SetItem(items[i]);
            }
            else
                itemSlots[i].ClearSlot();
        }
    }
}
