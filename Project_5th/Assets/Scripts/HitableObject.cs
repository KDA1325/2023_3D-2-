using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dropObjects; // �ش� ������Ʈ���� ������ �� �ִ� ������Ʈ �迭
    [SerializeField]
    private Transform spawnPoint; // �������� �����Ǵ� ��ġ
    [SerializeField]
    [Range(0, 100)]
    private int itemDropPercent = 0; // ������ ��� Ȯ�� (0~100%)
    private MeshRenderer meshRenderer;
    private Color originColor;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage}�� ���ظ� �Ծ����ϴ�.");

        StartCoroutine(nameof(OnHitAnimation));

        // ������ ��� Ȯ���� 0�̰ų� dropObject�� ��������� ������ ����X
        if(itemDropPercent != 0 && dropObjects.Length != 0 ) 
        { 
            // 0~99 ������ ������ ��ȯ�ϰ�, �� ���� 0~29�̸� ���ǹ� ���� ���� (30%)
            int percent = Random.Range(0, 100);
            if(percent < itemDropPercent)
            {
                // dropObjects �迭�� �ִ� ������Ʈ �� ������ ������Ʈ ����
                int index = Random.Range(0, dropObjects.Length);
                GameObject clone = Instantiate(dropObjects[index]);

                // ������ ������Ʈ�� ��ġ (������ ��ġ)
                // Vector3 additive = new Vector3(Random.Range(-2.0f, 2.0f), 2, Random.Range(-2.0f, 2.0f));
                // clone.transform.position = transform.position + additive;
                // ������ ������Ʈ�� ��ġ (Ư�� ������Ʈ ��ġ)
                clone.transform.position = spawnPoint.position;
                // ������ ������Ʈ�� ũ��
                clone.transform.localScale = new Vector3(5, 5, 5);
            }
        }
    }

    private IEnumerator OnHitAnimation()
    {
        meshRenderer.material.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
}
