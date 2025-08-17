using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : AnMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;


    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 21);
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProFileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                itemExist = this.CreateEmptyItem(itemProfile);
                if (this.IsInventoryFull()) return false;

                this.items.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }
    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }
        return null;
    }
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }
    public virtual ItemProFileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProFileSO));
        foreach (ItemProFileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
    protected virtual ItemInventory CreateEmptyItem(ItemProFileSO itemProFile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProFile,
            maxStack = itemProFile.defaultMaxStack
        };
        return itemInventory;
    }
    // protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    // {
    //     var profiles = Resources.LoadAll("Item", typeof(ItemProFileSO));
    //     foreach (ItemProFileSO profile in profiles)
    //     {
    //         if (profile.itemCode != itemCode) continue;
    //         ItemInventory itemInventory = new ItemInventory
    //         {
    //             itemProfile = profile,
    //             maxStack = profile.defaultMaxStack
    //         };
    //         this.items.Add(itemInventory);
    //         return itemInventory;
    //     }
    //     return null;
    // }
    // public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    // {
    //     ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    //     if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
    //     return itemInventory;
    // }
    //  public virtual bool DeductItem(ItemCode itemCode, int addCount)
    // {
    //     ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //     int newCount = itemInventory.itemCount - addCount;
    //     if (newCount < 0) return false;

    //     itemInventory.itemCount = newCount;
    //     return true;
    // }
    // public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
    // {
    //     ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //     int newCount = itemInventory.itemCount - addCount;
    //     if (newCount < 0) return false;
    //     return true;
    // }

}
