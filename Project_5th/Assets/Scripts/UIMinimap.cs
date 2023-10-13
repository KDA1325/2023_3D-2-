using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMinimap : MonoBehaviour
{
    [SerializeField]
    private Camera minimapCamera;
    [SerializeField]
    private float zoomMin = 1.0f;
    [SerializeField]
    private float zoomMax = 30.0f;
    [SerializeField]
    private float zoomStepSize = 1.0f;
    [SerializeField]
    private TextMeshProUGUI textMapInfo;

    private void Awake()
    {
        textMapInfo.text = SceneManager.GetActiveScene().name;
    }

    public void ZoomIn()
    {
        minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomStepSize, zoomMin);
    }

    public void ZoomOut()
    {
        minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomStepSize, zoomMax);
    }

    //== built-in Method ==
    //float result = Mathf.Max(float a, float b);
    //a와 b 중 더 큰 값을 반환
    //== built-in Method ==
    //float result = Mathf.Min(float a, float b);
    //a와 b 중 더 작은 값을 반환
}
