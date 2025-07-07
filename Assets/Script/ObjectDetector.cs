using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject respawnPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private TextMeshProUGUI textInteraction;
    private InteractableObject interactable;
    private string interactableName;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&& interactable != null)
        {
            SetupRespawnUI();

            interactable.Deactivate();
            interactable = null;
            textInteraction.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            interactable = other.GetComponent<InteractableObject>();

            if (textInteraction.enabled == false)
            {
                textInteraction.enabled = true;

                interactableName = other.name.Split('_')[0];
                textInteraction.text = $"{interactableName}\nF키를 눌러 상호작용해보세요.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            interactable = null;
            if(textInteraction.enabled == true)
            {
                textInteraction.enabled = false;
            }
        }
    }

    private void SetupRespawnUI()
    {
        GameObject clone = Instantiate(respawnPrefab);
        clone.transform.SetParent(canvasTransform);
        clone.transform.localScale = new Vector3(1, 1, 1); // Vector3.one;

        clone.GetComponent<UIPositionAutoSetter>().Setup(interactable.transform);
        clone.GetComponent<UIRespawn>().OnRespawn(interactableName, interactable.RespawnTime);
    }
}
