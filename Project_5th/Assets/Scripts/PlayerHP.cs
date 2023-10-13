using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float max = 100; // �ִ� ü��
    private float current; // ���� ü��
    private float normalDecrease = 1; // �ʴ� ���� ü��

    // �ܺο��� ü�� ������ ������ �� �ֵ��� Get Property ����
    public float Max => max;
    public float Current => current;
    // => ������, �� ���� ����, ��� �������� ��� �̸��� ������ �� ���
    // member => expression;
    // expression�� ��ȿ�� ��
    // ���� ����� ��ȯ ������ void�̰ų� ����� ������ �Ǵ� �������� ��쿡�� statement ���� �� ����
    // �� ���� ���Ǹ� ����ϸ� �����ϰ� ���� �� �ִ� �������� ��� ������ ����
    // �޼��� �Ǵ� �Ӽ��� ���� �����Ǵ� ����� ���� ���� ���� ������ ������ ��� ��� ����

    private void Awake()
    {
        current = max;
    }

    private void Update()
    {
        // ���� ü���� 0���� ũ�� �ʴ� 1�� ����
        if(current > 0)
        {
            current -= Time.deltaTime * normalDecrease;
        }
        // ���� ü���� 0�̸� �÷��̾� ��� ó��
        else
        {
            Debug.Log("�÷��̾� ��� ó��");
        }
    }
}
