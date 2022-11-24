using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BurgerNamespace {
  public class MoneyCounter : MonoBehaviour {
    public static MoneyCounter Instance;
    public int CurrentMoney = 0;

    public UnityAction OnMoneyChange;

    private void Awake() {
      Instance = this;
      
    }

    public void AddMoney(int amount) {
      CurrentMoney += amount;
      OnMoneyChange?.Invoke();
    }

    public bool IsEnoughMoney(int amount) {
      return CurrentMoney >= amount;
    }


    public bool Buy(int amount) {
      if (IsEnoughMoney(amount)) {
        CurrentMoney -= amount;
        OnMoneyChange?.Invoke();
        return true;
      }
      return false;
    }
  }
}
  
