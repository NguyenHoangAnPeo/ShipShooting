using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AnMonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = GetComponentInChildren<Inventory>();
    }
}
