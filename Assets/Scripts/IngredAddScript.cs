using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


namespace BurgerNamespace {
  public class IngredAddScript : MonoBehaviour {
    public int IngradValue = 1;
    public int IngradTough = 1;
    public int IngradRevard = 1;

    public int MaxIngredient = 2;
    public int CurrIngredient = 0;
    public string IngrName;
    public UnityEvent OnAmountChange;

    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;

    private void Awake() {
      OnAmountChange.RemoveAllListeners();
    }
    private void OnEnable() {
      _nameText.text = IngrName;
      _priceText.text = IngradValue.ToString();
      CurrIngredient = 0;
      AmountChange();
    }   
    public void Add() {
      if (CoinCounter.Instance.IsEnoughMoney(IngradValue)) {
        CoinCounter.Instance.Buy(IngradValue);
        CurrIngredient++;
        CurrIngredient = Mathf.Clamp(CurrIngredient, 0, MaxIngredient);
        AmountChange();
      }
      
    }
    public void Subtract() {
      CurrIngredient--;
      CurrIngredient = Mathf.Clamp(CurrIngredient, 0, MaxIngredient);
      AmountChange();
    }
    private void AmountChange() {
      _amountText.text = CurrIngredient.ToString();
      OnAmountChange?.Invoke();
    }
  }
}
