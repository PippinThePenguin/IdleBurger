using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  public class Pooler : MonoBehaviour {
    public static Pooler Singleton;
    [System.Serializable]
    public class Pool {
      public string Tag;
      public GameObject Prefab;
      public int Size;
    }
    public List<Pool> ListofPools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private Dictionary<string, Pool> pools;
    private void Awake() {
      Singleton = this;

      poolDictionary = new Dictionary<string, Queue<GameObject>>();
      pools = new Dictionary<string, Pool>();

      foreach (Pool pool in ListofPools) {
        Queue<GameObject> objectQueue = new Queue<GameObject>();
        pools.Add(pool.Tag, pool);
        for (int i = 0; i < pool.Size; i++) {
          GameObject obj = Instantiate(pool.Prefab);
          obj.transform.SetParent(transform);
          objectQueue.Enqueue(obj);
          obj.SetActive(false);
        }
        poolDictionary.Add(pool.Tag, objectQueue);
      }
    }
    public GameObject GetObjectFromPool(string tag) {
      if (!poolDictionary.ContainsKey(tag)) {
        Debug.LogWarning("Trying to access absent Pool!");
        return null;
      }
      if (poolDictionary[tag].Count != 0) {
        GameObject currentObj = poolDictionary[tag].Dequeue();
        currentObj.transform.SetParent(null);
        return currentObj;

      } else {
        GameObject currentObj = Instantiate(pools[tag].Prefab);
        return currentObj;
      }
    }

    public bool TakeObjectIntoPool(GameObject obj) {
      if (obj == null) {
        return false;
      }
      if (poolDictionary.ContainsKey(obj.tag)) {
        obj.transform.SetParent(transform);
        poolDictionary[obj.tag].Enqueue(obj);
        obj.SetActive(false);
        return true;
      } else {
        return false;
      }
      
    }
  }
}
  
