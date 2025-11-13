using UnityEngine;

public class FieldInteractObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    public Lever lever;
    public ClearObject clearObject;
    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if (data.type == ItemType.Interaction)
        {
            //Interaction 타입은 인벤토리에 추가 X
            if (lever != null)
            {
                lever.LeverControl(default);
            }
            else if (clearObject != null)
            {
                clearObject.ReStartScene();
                Debug.Log($"{data.displayName}은 상호작용 전용");
            }
        }
    }
}
