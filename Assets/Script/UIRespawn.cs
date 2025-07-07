using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
public class UIRespawn : MonoBehaviour
{
    [SerializeField]
    private Image imageFill;
    [SerializeField]
    private TextMeshProUGUI textRespawnTime;
    [SerializeField]
    private TextMeshProUGUI textObjectName;

    public void OnRespawn(string name, float respawnTime)
    {
        textObjectName.text = name;

        StartCoroutine(nameof(Process), respawnTime);
    }

    private IEnumerator Process(float respawnTime)
    {
        float currentRespawnTime = respawnTime;

        while(currentRespawnTime > 0)
        {
            currentRespawnTime -= Time.deltaTime;
            imageFill.fillAmount = currentRespawnTime / respawnTime;
            textRespawnTime.text = currentRespawnTime.ToString("F1");

            yield return null;
        }
        Destroy(gameObject);
    }
}
