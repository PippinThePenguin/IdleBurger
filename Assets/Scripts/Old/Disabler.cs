using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  public class Disabler : MonoBehaviour {

    private Pooler _pooler;
    void Start() {
      _pooler = Pooler.Singleton;
    }

    private void OnTriggerEnter(Collider other) {
      BurgerConstructor burgerConstructor = other.GetComponent<BurgerConstructor>();
      if (burgerConstructor != null) {
        MoneyCounter.Instance.AddMoney(burgerConstructor.BurgerValue);
        foreach (Transform t in burgerConstructor.DisasembleBurger()) {
          TryDisable(t);
        }
      }
      

      TryDisable(other.transform);
      
    }

    private void TryDisable(Transform t) {
      var toPool = _pooler.TakeObjectIntoPool(t.gameObject);
      if (!toPool) {
        t.parent = transform;
        t.gameObject.SetActive(false);
      }
    }
  }

}
