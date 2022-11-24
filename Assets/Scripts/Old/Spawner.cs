using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BurgerNamespace {
  public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private int _cooldown = 1200;
    
    private void Start () {
      InputHandler.Instance.TapAction.performed += Spawn;
      TimeSpawn();
    }

    private async void TimeSpawn () {
      while (this.enabled) {
        await Task.Delay(_cooldown);
        Spawn(new InputAction.CallbackContext());
      }
    }
    public void Spawn(InputAction.CallbackContext obj) {
      GameObject newObject = Pooler.Singleton.GetObjectFromPool("Burger");
      //GameObject newObject = Instantiate(_prefab);
      newObject.transform.position = transform.position + _position;   
      newObject.SetActive(true);
    }
  }
}
  
