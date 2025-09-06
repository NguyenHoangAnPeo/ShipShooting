using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectAbstract : AnMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjCtrl();
    }
    protected virtual void LoadShootableObjCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + "LoadShootableObjCtrl", gameObject);
    }
}
