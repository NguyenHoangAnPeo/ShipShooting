using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    [SerializeField] protected static UIInvItemSpawner instance;
    [SerializeField] public static UIInvItemSpawner Instance => instance;

    [Header("Inventory Item Spawner")]

    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

    public static string normalItem = "UIInvItem";

    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.Log("Only 1 UIInvItemSpawner is exits");
        UIInvItemSpawner.instance = this;
    }
    protected override void LoadHolders()
    {
        LoadUIInventoryCtrl();

        if (this.holders != null) return;
        this.holders = this.uIInventoryCtrl.Content;
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log(transform.name + ": UIInventoryCtrl", gameObject);
    }
    public virtual void ClearItems()
    {
        foreach(Transform item in this.holders)
        {
            this.Despawn(item);
        }
    }
    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.UIInventoryCtrl.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}
