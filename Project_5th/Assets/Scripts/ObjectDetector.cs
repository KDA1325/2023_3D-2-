using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.ParticleSystem;
using UnityEngine.XR;
using static UnityEngine.UI.Image;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject respawnPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private TextMeshProUGUI textInteraction;
    private InteractableObject interactable;
    private string interactableName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactable != null)
        {
            SetupRespawnUI();

            interactable.Deactivate();
            interactable = null;
            textInteraction.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        
        if(other.CompareTag("Interactable"))
        {
            interactable = other.GetComponent<InteractableObject>();

            if(textInteraction.enabled == false)
            {
                textInteraction.enabled = true;

                //string name = other.name.Split('_')[0];
                ////string[] results = string.Split(char separator);
                ////매개변수에 입력한 문자를 기준으로 문자열을 분할

                //textInteraction.text = $"{name}\nF키를 눌러 상호작용해보세요.";

                interactableName = other.name.Split('_')[0];
                textInteraction.text = $"{interactableName}\nF키를 눌러 상호작용해보세요.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            interactable = null;

            if(textInteraction.enabled == true)
            {
                textInteraction.enabled = false;
            }
        }
    }

    private void SetupRespawnUI()
    {
        GameObject clone = Instantiate(respawnPrefab);
        clone.transform.SetParent(canvasTransform);
        clone.transform.localScale = Vector3.one;

        // UI가 쫓아다닐 대상을 방금 비활성화한 상호작용 오브젝트로 설정
        clone.GetComponent<UIPositionAutoSetter>().Setup(interactable.transform);
        // UI에 방금 상호작용한 오브젝트의 이름과 Respawn 시간 전달
        clone.GetComponent<UIRespawn>().OnRespawn(interactableName, interactable.RespawnTime);
    }

    //== built-in method ==
    //GameObject clone = Instantiate(GameObject original);
    //original과 완전히 동일한 게임 오브젝트를 게임 월드에 생성
    //대입 연산자를 이용해 방금 생성한 오브젝트 정보를 변수에 할당 가능
}


//== built -in Method ==
//GameObject.SetActive(bool visible);
//해당 게임오브젝트를 활성 or 비활성화
//== built-in Property ==
//Component.enabled
//해당 컴포넌트의 활성/비활성 설정 및 확인