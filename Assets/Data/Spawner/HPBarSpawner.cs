using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    [SerializeField] protected static HPBarSpawner instance;
    [SerializeField] public static HPBarSpawner Instance => instance;
    public static string HPBar = "HPBar";
    protected override void Awake()
    {
        base.Awake();
        if (HPBarSpawner.instance != null) Debug.Log("Only 1 HPBarSpawner is exits");
        HPBarSpawner.instance = this;
    }

}
