using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : JunkAbstract
{
    [Header("ItemPickupable")]
    [SerializeField] protected SphereCollider _collider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }
    public virtual void OnMouseDown()
    {
        //Debug.Log(transform.parent.name);
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + "LoadTrigger and SphereCollider", gameObject);
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
