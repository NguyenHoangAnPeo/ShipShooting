using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : AnMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    [SerializeField] public ItemDespawn ItemDespawn => itemDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if(this.itemDespawn != null)return;
        this.itemDespawn = transform.parent.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name+ "LoadItemDespawn",gameObject);
    }
}
