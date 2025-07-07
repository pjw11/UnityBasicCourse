using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStaminaViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerStamina playerStamina;
    [SerializeField]
    private TextMeshProUGUI textStamina;
    private Slider sliderStamina;

    private void Awake()
    {
        sliderStamina = GetComponent<Slider>();
    }
    private void Update()
    {
        sliderStamina.value = playerStamina.Current / playerStamina.Max;
        textStamina.text = $"스태미나 {playerStamina.Current:F0}/{playerStamina.Max}";
    }
}
