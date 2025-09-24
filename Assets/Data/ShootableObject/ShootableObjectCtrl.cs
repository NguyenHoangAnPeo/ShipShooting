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
    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;
    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;
    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
        this.LoadSpawner();
    }
     protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + "Loadspawner", gameObject);
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + "LoadObjShooting", gameObject);
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + "LoadObjLookAtTarget", gameObject);
    }
     protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + "LoadObjMovement", gameObject);
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
