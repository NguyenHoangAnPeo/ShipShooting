using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : AnMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + "LoadPlayerCtrl", gameObject);
    }
}
