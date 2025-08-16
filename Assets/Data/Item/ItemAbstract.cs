using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : AnMonoBehaviour
{
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl {get=> itemCtrl;}
    
    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl(){
        if(this.itemCtrl != null)return;
        this.itemCtrl = transform.parent.GetComponentInChildren<ItemCtrl>();
        Debug.Log(transform.name+ "LoadModel",gameObject);
    }
}
