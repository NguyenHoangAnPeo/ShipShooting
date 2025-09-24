using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
   [SerializeField] protected static MotherShipSpawner instance;
   [SerializeField] public static MotherShipSpawner Instance{get => instance;}
    protected override void Awake()
    {
        base.Awake();
         if(MotherShipSpawner.instance != null)Debug.Log("Only 1 MotherShipSpawner is exits");
        MotherShipSpawner.instance = this;
    }

}
