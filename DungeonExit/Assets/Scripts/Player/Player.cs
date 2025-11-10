using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public UIInventory inventory;

    public ItemData itemData;
    public Action<ItemData> addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        inventory = FindObjectOfType<UIInventory>();

        addItem += inventory.AddItem;
    }
}
