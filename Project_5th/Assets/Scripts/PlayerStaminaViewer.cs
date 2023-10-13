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
    private TextMeshProUGUI textStamina; // �÷��̾��� ���¹̳� �ؽ�Ʈ�� ����ϴ� Text UI
    private Slider sliderStamina; // �÷��̾��� ���¹̳��� �� ���·� ����ϴ� Slider UI

    private void Awake()
    {
        sliderStamina = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderStamina.value = playerStamina.Current / playerStamina.Max;
        textStamina.text = $"���¹̳� {playerStamina.Current:F0} / {playerStamina.Max}";
    }
}
