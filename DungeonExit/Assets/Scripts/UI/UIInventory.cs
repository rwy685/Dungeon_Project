using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public ItemSlot[] itemSlots;

    public void AddItem(ItemData newItem)
    {
        // 1) 스택 가능한 경우 먼저 기존 슬롯을 조사
        if (newItem.canStack)
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                if (itemSlots[i].currentItem == newItem)
                {
                    // 스택이 꽉 찼는지 체크
                    if (itemSlots[i].quantity < newItem.maxStackAmount)
                    {
                        itemSlots[i].AddQuantity(1);
                        return;
                    }
                    // 꽉 찼으면 다음 빈 슬롯을 찾도록 넘어감
                }
            }
        }

        // 2) 스택할 슬롯을 찾지 못했으면 빈 슬롯 찾기
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].currentItem == null)
            {
                itemSlots[i].SetItem(newItem);
                items.Add(newItem);
                return;
            }
        }

        // 3) 인벤토리가 꽉 찬 경우
        Debug.Log("인벤토리가 가득 찼습니다.");
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= itemSlots.Length)
            return;

        ItemSlot slot = itemSlots[index];

        if (slot.currentItem == null)
            return;

        ApplyItemEffect(slot.currentItem);

        // 수량 1 감소
        slot.quantity--;
        if (slot.quantity > 0)
        {
            slot.quantityText.text = slot.quantity.ToString();
        }
        else
        {
            // 수량이 0이면 슬롯 비우기
            slot.ClearSlot();
            items[index] = null;
        }
    }

    void ApplyItemEffect(ItemData item)
    {
        if (item.type != ItemType.Consumable)
        {
            return;
        }

        if (item.consumables == null || item.consumables.Length == 0)
        {
            return;
        }

        foreach (var c in item.consumables)
        {
            if (c.Type == ConsumableType.Health)
            {
                CharacterManager.Instance.Player.condition.Heal(c.value);
            }
            else if (c.Type == ConsumableType.JumpBoost)
            {
                CharacterManager.Instance.Player.controller.BoostJump(c.value);
            }
        }
    }
}

