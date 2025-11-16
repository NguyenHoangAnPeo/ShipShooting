using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProFileSO", menuName = "SO/ItemProFile")]
public class ItemProFileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public Sprite itemSprite;
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgradeLevels;
    public static ItemProFileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item",typeof(ItemProFileSO));
        foreach (ItemProFileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
}
