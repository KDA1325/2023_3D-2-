using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStaminaViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerStamina playerStamina;
    [SerializeField]
    private TextMeshProUGUI textStamina; // 플레이어의 스태미나 텍스트를 출력하는 Text UI
    private Slider sliderStamina; // 플레이어의 스태미나를 바 형태로 출력하는 Slider UI

    private void Awake()
    {
        sliderStamina = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderStamina.value = playerStamina.Current / playerStamina.Max;
        textStamina.text = $"스태미나 {playerStamina.Current:F0} / {playerStamina.Max}";
    }
}
