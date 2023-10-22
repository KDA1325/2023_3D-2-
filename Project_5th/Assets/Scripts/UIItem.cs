using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private UIInventory uiInventory;
    [SerializeField]
    private TextMeshProUGUI textItemCount;

    //private int itemCount;
    [SerializeField]
    private ItemData itemData;

    public int Count
    {
        set
        {
            itemData.count = Mathf.Clamp(value, 0, 9999);
            textItemCount.text = itemData.count.ToString();
        }
        get => itemData.count;
    }
    public Sprite Icon => itemData.icon;
    public string Name => itemData.name;
    public string Details => itemData.details;
    public int HPRecovery => itemData.hpRecovery;

    private void Awake()
    {
        Count = 0;
    }

    // IPointerClickHandler 인터페이스를 추가했기 때문에 정의하는 메소드
    public void OnPointerClick(PointerEventData eventData)
    {
        uiInventory.UpdateCurrentItem(this);
    }
}
