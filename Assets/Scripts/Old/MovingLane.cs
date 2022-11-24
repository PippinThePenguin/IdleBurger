using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  public class MovingLane : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Transform> _burgers;
    private void Start() {
      _burgers = new List<Transform>();
    }

    private void FixedUpdate() {
      foreach (Transform obj in _burgers) {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(_moveSpeed, rb.velocity.y, rb.velocity.z);
      }
    }

    private void OnCollisionEnter(Collision collision) {
      if (collision.transform.tag == "Burger") {
        _burgers.Add(collision.transform);
      }
    }

    private void OnCollisionExit(Collision collision) {
      if (collision.transform.tag == "Burger") {
        _burgers.Remove(collision.transform);
      }
    }
  }
}

