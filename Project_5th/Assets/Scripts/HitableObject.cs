using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
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
    }

    private IEnumerator OnHitAnimation()
    {
        meshRenderer.material.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
}
