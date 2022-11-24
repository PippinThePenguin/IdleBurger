using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BurgerNamespace {
  public class CanvasController : MonoBehaviour {
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _coinText;
    private MoneyCounter _moneyCounter;
    void Start() {
      _moneyCounter = MoneyCounter.Instance;
      _moneyCounter.OnMoneyChange += MoneyTextUpdate;
      CoinCounter.Instance.OnMoneyChange += CoinTextUpdate;
      MoneyTextUpdate();
      CoinTextUpdate();
    }

    private void CoinTextUpdate() {
      _coinText.text = CoinCounter.Instance.CurrentCoins.ToString();
    }

    private void MoneyTextUpdate() {
      _moneyText.text = _moneyCounter.CurrentMoney.ToString();
    }
  }

}
