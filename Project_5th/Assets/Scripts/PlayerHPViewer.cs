using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP; // �÷��̾��� ü�� ����
    [SerializeField]
    private TextMeshProUGUI textHP; // �÷��̾��� ü�� �ؽ�Ʈ�� ����ϴ� Text UI
    private Slider sliderHP; // �÷��̾��� ü���� �� ���·� ����ϴ� Slider UI

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    // UnityEvent ���� �̿��� ü�� ������ �ٲ� ���� UI ������ �����ϴ� ���� �� �ٶ���
    private void Update()
    {
        // ���� ü�� / �ִ� ü������ 0.0 ~ 1.0 ������ ���� ������ Slider UI�� ���
        sliderHP.value = playerHP.Current / playerHP.Max;
        // float Ÿ���� playerHP.Current ���� int Ÿ������ �� ��ȯ
        textHP.text = $"ü�� {(int)playerHP.Current}/{playerHP.Max}";
    }
}
