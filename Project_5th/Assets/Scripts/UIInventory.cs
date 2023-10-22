using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel; // 인벤토리
    [SerializeField]
    private UIItem[] items; // 인벤토리에 있는 아이템 정보

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
