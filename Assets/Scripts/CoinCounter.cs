using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BurgerNamespace {
  public class CoinCounter : MonoBehaviour {
    public static CoinCounter Instance;
    public int CurrentCoins = 0;

    public UnityAction OnMoneyChange;

    private void Awake() {
      Instance = this;

    }

    public void AddMoney(int amount) {
      CurrentCoins += amount;
      OnMoneyChange?.Invoke();
    }

    public bool IsEnoughMoney(int amount) {
      return CurrentCoins >= amount;
    }


    public bool Buy(int amount) {
      if (IsEnoughMoney(amount)) {
        CurrentCoins -= amount;
        OnMoneyChange?.Invoke();
        return true;
      }
      return false;
    }
  }
}
  
