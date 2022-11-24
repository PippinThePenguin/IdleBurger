using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BurgerNamespace {
  public class PriceManager : MonoBehaviour {
    public int ClickPrice;
    public int SpeedPrice;    
    public int MoneyPrice;    
    public int IncomeFactor = 1;
    public PriceCreep CurrentPriceCreep;
    public PriceCreep CurrentValueCreep;
    [SerializeField] private TMP_Text _clickUpgrageText;
    [SerializeField] private TMP_Text _speedUpgrageText;
    [SerializeField] private TMP_Text _moneyUpgrageText;
    

    private MoneyCounter _moneyCounter;

    void Start() {
      _moneyCounter = MoneyCounter.Instance;
      ClickController.Instance.OnBurgerBite.AddListener(AddMoney);
      CurrentPriceCreep.ClearNodes();
      CurrentValueCreep.ClearNodes();
      ClickPrice = CurrentPriceCreep.ReturnNextClickPrice();
      SpeedPrice = CurrentPriceCreep.ReturnNextSpeedPrice();
      MoneyPrice = CurrentPriceCreep.ReturnNextMoneyPrice();
      _clickUpgrageText.text = ClickPrice.ToString();
      _speedUpgrageText.text = SpeedPrice.ToString();
      _moneyUpgrageText.text = MoneyPrice.ToString();
      var clickval = CurrentValueCreep.ReturnNextClickPrice();
      AutoClicker.Instance.BetterClick(clickval);
      ClickController.Instance.BetterClick(clickval);
      AutoClicker.Instance.ReduceDelay(CurrentValueCreep.ReturnNextSpeedPrice());
      IncomeFactor = CurrentValueCreep.ReturnNextMoneyPrice();
    }
    
    public void BuyClick() {
      if (_moneyCounter.IsEnoughMoney(ClickPrice)) {
        _moneyCounter.Buy(ClickPrice);
        var clickval = CurrentValueCreep.ReturnNextClickPrice();
        AutoClicker.Instance.BetterClick(clickval);
        ClickController.Instance.BetterClick(clickval);
        ClickPrice = CurrentPriceCreep.ReturnNextClickPrice();
        _clickUpgrageText.text = ClickPrice.ToString();
      }
    }

    public void BuySpeed() {
      if (_moneyCounter.IsEnoughMoney(SpeedPrice)) {
        _moneyCounter.Buy(SpeedPrice);
        AutoClicker.Instance.ReduceDelay(CurrentValueCreep.ReturnNextSpeedPrice());
        SpeedPrice = CurrentPriceCreep.ReturnNextSpeedPrice();
        _speedUpgrageText.text = SpeedPrice.ToString();
      }
    }

    public void BuyMoney() {
      if (_moneyCounter.IsEnoughMoney(MoneyPrice)) {
        _moneyCounter.Buy(MoneyPrice);
        IncomeFactor = CurrentValueCreep.ReturnNextMoneyPrice();
        MoneyPrice = CurrentPriceCreep.ReturnNextMoneyPrice();
        _moneyUpgrageText.text = MoneyPrice.ToString();
      }
    }

    public void AddMoney(int amount) {
      _moneyCounter.AddMoney(amount * IncomeFactor);
    }
  }
}
  
