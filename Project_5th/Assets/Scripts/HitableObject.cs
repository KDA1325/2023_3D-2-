using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dropObjects; // 해당 오브젝트에서 생성할 수 있는 오브젝트 배열
    [SerializeField]
    private Transform spawnPoint; // 아이템이 생성되는 위치
    [SerializeField]
    [Range(0, 100)]
    private int itemDropPercent = 0; // 아이템 드롭 확률 (0~100%)
    private MeshRenderer meshRenderer;
    private Color originColor;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage}의 피해를 입었습니다.");

        StartCoroutine(nameof(OnHitAnimation));

        // 아이템 드롭 확률이 0이거나 dropObject가 비어있으면 아이템 생성X
        if(itemDropPercent != 0 && dropObjects.Length != 0 ) 
        { 
            // 0~99 사이의 정수를 반환하고, 그 값이 0~29이면 조건문 내부 실행 (30%)
            int percent = Random.Range(0, 100);
            if(percent < itemDropPercent)
            {
                // dropObjects 배열에 있는 오브젝트 중 임의의 오브젝트 생성
                int index = Random.Range(0, dropObjects.Length);
                GameObject clone = Instantiate(dropObjects[index]);

                // 생성한 오브젝트의 위치 (임의의 위치)
                // Vector3 additive = new Vector3(Random.Range(-2.0f, 2.0f), 2, Random.Range(-2.0f, 2.0f));
                // clone.transform.position = transform.position + additive;
                // 생성한 오브젝트의 위치 (특정 오브젝트 위치)
                clone.transform.position = spawnPoint.position;
                // 생성한 오브젝트의 크기
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
