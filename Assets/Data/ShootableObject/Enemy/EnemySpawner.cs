using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
   [SerializeField] protected static EnemySpawner instance;
   [SerializeField] public static EnemySpawner Instance{get => instance;}
   public static string meteoriteOne = "Meteorite_1";
    protected override void Awake()
    {
        base.Awake();
         if(EnemySpawner.instance != null)Debug.Log("Only 1 EnemySpawner is exits");
        EnemySpawner.instance = this;
    }

}
