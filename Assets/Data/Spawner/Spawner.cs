using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : AnMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    [SerializeField] protected List<Transform> prefabs; // Khởi tạo danh sách
    // Hàm dùng để tải các thành phần
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    // Hàm tải danh sách Prefabs
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs"); // Tìm đối tượng con có tên "Prefabs"
        if (prefabObj == null) // Kiểm tra null
        {
            Debug.LogWarning("Không tìm thấy đối tượng Prefabs trong " + gameObject.name);
            return;
        }

        // Thêm tất cả đối tượng con của "Prefabs" vào danh sách
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        // Ẩn các đối tượng Prefabs
        this.HidePrefabs();
    }

    // Hàm ẩn tất cả các Prefabs
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab != null) // Kiểm tra null trước khi thực hiện
            {
                prefab.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Một prefab trong danh sách bị null.");
            }
        }
    }
    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Can not get prefab" + prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetParent (this.holder,true);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        this.spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
