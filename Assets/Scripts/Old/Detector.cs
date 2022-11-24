using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BurgerNamespace {
  public class Detector : MonoBehaviour {
    public string TargetTag = "Burger";
    public UnityAction<Transform> OnDetection;

    private void Awake() {
      
    }
    private void Start() {

    }

    private void OnTriggerEnter(Collider other) {
      if (other.tag == TargetTag) {
        //Debug.Log("Burger!");
        OnDetection?.Invoke(other.transform);
      }
    }
    
  }

}
