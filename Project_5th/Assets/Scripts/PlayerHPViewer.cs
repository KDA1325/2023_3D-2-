using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP; // 플레이어의 체력 정보
    [SerializeField]
    private TextMeshProUGUI textHP; // 플레이어의 체력 텍스트를 출력하는 Text UI
    private Slider sliderHP; // 플레이어의 체력을 바 형태로 출력하는 Slider UI

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    // UnityEvent 등을 이용해 체력 정보가 바뀔 때만 UI 정보를 갱신하는 것이 더 바람직
    private void Update()
    {
        // 현재 체력 / 최대 체력으로 0.0 ~ 1.0 사이의 값을 연산해 Slider UI에 출력
        sliderHP.value = playerHP.Current / playerHP.Max;
        // float 타입의 playerHP.Current 값을 int 타입으로 형 변환
        textHP.text = $"체력 {(int)playerHP.Current}/{playerHP.Max}";
    }
}
