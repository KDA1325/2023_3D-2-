using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float max = 100; // 최대 체력
    private float current; // 현재 체력
    private float normalDecrease = 1; // 초당 감소 체력

    // 외부에서 체력 정보를 열람할 수 있도록 Get Property 정의
    public float Max => max;
    public float Current => current;
    // => 연산자, 식 본문 정의, 멤버 구현에서 멤버 이름을 구분할 때 사용
    // member => expression;
    // expression은 유효한 식
    // 식은 멤버의 반환 형식이 void이거나 멤버가 생성자 또는 종료자인 경우에만 statement 식일 수 있음
    // 식 본문 정의를 사용하면 간결하고 읽을 수 있는 형식으로 멤버 구현을 제공
    // 메서드 또는 속성과 같은 지원되는 멤버에 대한 논리가 단일 식으로 구성된 경우 사용 가능

    private void Awake()
    {
        current = max;
    }

    private void Update()
    {
        // 현재 체력이 0보다 크면 초당 1씩 감소
        if(current > 0)
        {
            current -= Time.deltaTime * normalDecrease;
        }
        // 현재 체력이 0이면 플레이어 사망 처리
        else
        {
            Debug.Log("플레이어 사망 처리");
        }
    }
}
