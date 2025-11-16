using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIHotKeyCtrl : AnMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance { get => instance; }

    [SerializeField] public List<ItemSlot> itemSlots;
    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) return;
        UIHotKeyCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }
    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlots);
        Debug.Log(transform.name + "LoadItemSlot", gameObject);
    }
}
