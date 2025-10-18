using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : AnMonoBehaviour
{
    [Header("UI Inventory abstract")]

    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }
}
