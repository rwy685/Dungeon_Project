using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera camera_3;

    void Start()
    {
        camera_3 = Camera.main;
    }
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera_3.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            
            //Ray 시작점 플레이어 기준으로 변경
            Vector3 rayOrigin = transform.position + Vector3.up * 1.5f; // 캐릭터 머리높이
            Vector3 rayDirection = (ray.GetPoint(10f) - rayOrigin).normalized; //카메라 방향교차

            RaycastHit hit;

            if (Physics.SphereCast(rayOrigin, 0.5f, rayDirection, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    if (curInteractable != null)
                    {
                        SetpromptText();
                    }
                    else
                    {
                        promptText.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable=null;
                promptText.gameObject.SetActive(false);

            }

            Debug.DrawRay(rayOrigin, rayDirection * maxCheckDistance, Color.red);
        }


    }

    private void SetpromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }
}
