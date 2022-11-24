using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BurgerNamespace {
  public class Dispencer : MonoBehaviour {
    [SerializeField] private int _cooldown;
    [SerializeField] private bool _isReady;
    [SerializeField] private Detector _detector;
    [SerializeField] private string _dropTag;


    
    private void Start() {
      _detector.OnDetection += BurgerProccess;
      _isReady = true;
    }

    private void BurgerProccess(Transform arg0) {
      if (!_isReady) {
        return;
      }
      //Debug.Log("Got Burger!");
      StartCooldown();
      SpawnDrop();
      
    }

    private void SpawnDrop() {
      var newObject = Pooler.Singleton.GetObjectFromPool(_dropTag);
      newObject.transform.SetParent(null);
      newObject.transform.position = transform.position;
      newObject.SetActive(true);

    }

    private async void StartCooldown() {
      _isReady = false;
      await Task.Delay(_cooldown);
      _isReady = true;
    }
  }
}
 
