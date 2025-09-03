using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : AnMonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl => abilityObjectCtrl;
     protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjCtrl();
    }
    protected virtual void LoadAbilityObjCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();
        Debug.Log(transform.name + "LoadAbilityObjCtrl", gameObject);
    }
}
