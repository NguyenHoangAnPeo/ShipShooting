using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
   [SerializeField] protected static FXSpawner instance;
   [SerializeField] public static FXSpawner Instance => instance;
   public static string smoke_1a = "Smoke_1a";
    protected override void Awake()
    {
        base.Awake();
         if(FXSpawner.instance != null)Debug.Log("Only 1 FXSpawner is exits");
        FXSpawner.instance = this;
    }

}
