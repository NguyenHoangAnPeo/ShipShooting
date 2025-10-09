using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
   [SerializeField] protected static EnemySpawner instance;
   [SerializeField] public static EnemySpawner Instance{get => instance;}
    protected override void Awake()
    {
        base.Awake();
         if(EnemySpawner.instance != null)Debug.Log("Only 1 EnemySpawner is exits");
        EnemySpawner.instance = this;
    }
    public override Transform Spawn(Transform prefab,Vector2 spawnPos, Quaternion spawnRot)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, spawnRot);
        this.AddHPBarToObj(newEnemy);

        return newEnemy;
    }
    protected virtual void AddHPBarToObj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }
}
