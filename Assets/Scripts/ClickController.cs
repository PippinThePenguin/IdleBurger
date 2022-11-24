using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace BurgerNamespace {
  public class ClickController : MonoBehaviour {
    public static ClickController Instance;

    public UnityEvent<int> OnBurgerBite;
    [SerializeField] private int _moneyOnPlayerClick = 1;

    private InputHandler _inputHandler;
    private MoneyCounter _moneyCounter;

    private void Awake() {
      OnBurgerBite.RemoveAllListeners();
      Instance = this;
    }
    private void Start() {
      _inputHandler = InputHandler.Instance;
      _moneyCounter = MoneyCounter.Instance;
      _inputHandler.TapAction.performed += OnPlayerTap;
    }

    public void BetterClick(int newValue) {
      _moneyOnPlayerClick = newValue;
    }

    private void OnPlayerTap(InputAction.CallbackContext obj) {
      //Debug.Log("Click!");
      //EZCameraShake.CameraShaker.Instance.ShakeOnce(2, 1, 0.1f, 0.1f);
      OnBurgerBite?.Invoke(_moneyOnPlayerClick);
    }

    
  }
}
 
