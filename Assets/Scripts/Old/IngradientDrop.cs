using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BurgerNamespace {
  public class IngradientDrop : MonoBehaviour {
    [SerializeField] private int _value = 2;
    private void OnEnable() {
      //Debug.Log("enableCheese");
      Rigidbody rb = gameObject.AddComponent<Rigidbody>();
      transform.GetComponent<Collider>().isTrigger = true;
      rb.velocity = Vector3.zero;
    }

    private void OnDisable() {
      transform.GetComponent<Collider>().isTrigger = false;
      Rigidbody rb = transform.GetComponent<Rigidbody>();
      Destroy(rb);
    }

    private void OnTriggerEnter(Collider other) {
      //Debug.Log(other.gameObject.name);
      BurgerConstructor constructor = other.GetComponent<BurgerConstructor>();
      if (constructor == null) {
        return;
      }
      //Debug.Log("Nice!");
      constructor.StackBurger(transform);
      constructor.AddValue(_value);
      transform.GetComponent<Collider>().isTrigger = false;
      Rigidbody rb = transform.GetComponent<Rigidbody>();
      Destroy(rb);
    }
  }
}
  
