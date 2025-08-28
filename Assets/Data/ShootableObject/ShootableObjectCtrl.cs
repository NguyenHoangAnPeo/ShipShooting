using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : AnMonoBehaviour
{
    [SerializeField] protected Despawn despawn;
    [SerializeField] public Despawn Despawn => despawn;
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + "LoadDespawn", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + "LoadModel", gameObject);

    }
    protected virtual void LoadSO()
    {
        if (this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeString() + "/" + transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadShootableObjectSO" + resPath, gameObject);
    }
    protected abstract string GetObjectTypeString();
}
