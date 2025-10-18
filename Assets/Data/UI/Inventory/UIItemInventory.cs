using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : AnMonoBehaviour
{
    [Header("UI Item Inventory")]

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
    }
    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }
    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemNumber", gameObject);
    }
    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString(); 
    }
}
