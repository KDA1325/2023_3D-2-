using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel; // �κ��丮
    [SerializeField]
    private UIItem[] items; // �κ��丮�� �ִ� ������ ����

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
    
    public void GetItem(int index)
    {
        items[index].ItemCount++;
    }
}
