using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : AnMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    [SerializeField] public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    [SerializeField] public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }
    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProFileSO itemProFile = ItemProFileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProFile;
        this.ResetItem();
        Debug.Log(transform.name + "LoadInventory", gameObject);
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = gameObject.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + "LoadItemDespawn", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        //this.itemInventory = itemInventory;
        this.itemInventory = itemInventory.Clone();
    }
    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
