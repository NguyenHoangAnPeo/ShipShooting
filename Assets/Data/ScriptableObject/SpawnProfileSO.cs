using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Spawn/SpawnProfile")]
public class SpawnProfileSO : ScriptableObject
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public ShootableObjectSO enemyData;
        public int minLevel = 1;
        public int maxLevel = 20;
    }
    public string profileName;
    public int baseLimit = 5;
    public float baseInterval = 15f; //thoi gian giua cac luot spawn

    [Header("Enemy Pool")]
    public EnemySpawnData[] enemyList;
}
