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
                ////�Ű������� �Է��� ���ڸ� �������� ���ڿ��� ����

                //textInteraction.text = $"{name}\nFŰ�� ���� ��ȣ�ۿ��غ�����.";

                interactableName = other.name.Split('_')[0];
                textInteraction.text = $"{interactableName}\nFŰ�� ���� ��ȣ�ۿ��غ�����.";
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

        // UI�� �Ѿƴٴ� ����� ��� ��Ȱ��ȭ�� ��ȣ�ۿ� ������Ʈ�� ����
        clone.GetComponent<UIPositionAutoSetter>().Setup(interactable.transform);
        // UI�� ��� ��ȣ�ۿ��� ������Ʈ�� �̸��� Respawn �ð� ����
        clone.GetComponent<UIRespawn>().OnRespawn(interactableName, interactable.RespawnTime);
    }

    //== built-in method ==
    //GameObject clone = Instantiate(GameObject original);
    //original�� ������ ������ ���� ������Ʈ�� ���� ���忡 ����
    //���� �����ڸ� �̿��� ��� ������ ������Ʈ ������ ������ �Ҵ� ����
}


//== built -in Method ==
//GameObject.SetActive(bool visible);
//�ش� ���ӿ�����Ʈ�� Ȱ�� or ��Ȱ��ȭ
//== built-in Property ==
//Component.enabled
//�ش� ������Ʈ�� Ȱ��/��Ȱ�� ���� �� Ȯ��