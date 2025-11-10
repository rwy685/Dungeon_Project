using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if (data.type == ItemType.Consumable || data.type == ItemType.Resource)
        {
            CharacterManager.Instance.Player.addItem?.Invoke(data);
            Destroy(gameObject);
        }
        else if (data.type == ItemType.Interaction)
        {
            //Interaction 타입은 인벤토리에 추가 X
            Debug.Log($"{data.displayName}은 상호작용 전용");
        }
        
    }
}
