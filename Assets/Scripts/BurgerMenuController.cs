//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace BurgerNamespace {
  public class BurgerMenuController : MonoBehaviour {
    public static BurgerMenuController Instance;
    public UnityEvent OnBurgerMenuDisable;
    public UnityEvent OnBurgerMenuEnable;
    [SerializeField] private Transform _burgerMenu;
    [SerializeField] private TMP_Text _confirmText;
    [SerializeField] private List<IngredAddScript> _ingredScripts;
    private InputHandler _inputHandler;
    private BurgerDroper _burgerDroper;
    private int _value = 0;
    private void Awake() {
      Instance = this;
      OnBurgerMenuDisable.RemoveAllListeners();
      OnBurgerMenuEnable.RemoveAllListeners();
    }
    void Start() {
      _inputHandler = InputHandler.Instance;
      _burgerDroper = BurgerDroper.Instance;  
      foreach (IngredAddScript script in _ingredScripts) {
        //script.OnAmountChange.AddListener(RecalculateValue);
      }
      _burgerMenu.gameObject.SetActive(false);
    }
    public void TryConfirm() {
      var moneyCounter = CoinCounter.Instance;
      if (moneyCounter.IsEnoughMoney(_value)) {
        moneyCounter.Buy(_value);
        ToBurgerEating();
      }
    }
    public void ToBurgerMenu() {
      _burgerMenu.gameObject.SetActive(true);
      //RecalculateValue();
      _inputHandler.ActionMap.Disable();
      OnBurgerMenuEnable?.Invoke();
    }
    public void ToBurgerEating() {
      _inputHandler.ActionMap.Enable();
      CalculateNewBurger();
      MakeNewBurger();
      _burgerMenu.gameObject.SetActive(false);    
      OnBurgerMenuDisable?.Invoke();

    }

    private void CalculateNewBurger() {
      int newTougth = 20;
      int newVal = 20;
      foreach (IngredAddScript script in _ingredScripts) {
        newTougth += script.CurrIngredient * script.IngradTough;
        newVal += script.CurrIngredient * script.IngradRevard;
      }
      BurgerController.Instance._coinsPerBurger = newVal;
      BurgerController.Instance._defBurgerHP = newTougth;
    }

    public void MakeNewBurger() {
      List<string> burgerList = new List<string>();
      burgerList.Add("LBun");
      foreach (IngredAddScript script in _ingredScripts) {
        for (int i = 0; i < script.CurrIngredient; i++) {
          burgerList.Add(script.IngrName);
        }
      }
      
      for (int i = 1; i < burgerList.Count; i++) {
        string temp = burgerList[i];
        int randomIndex = Random.Range(i, burgerList.Count);
        burgerList[i] = burgerList[randomIndex];
        burgerList[randomIndex] = temp;
      }
      burgerList.Add("TBun");
      burgerList.ForEach(p => Debug.Log(p));
      _burgerDroper.BurgerList = burgerList;

      //Debug.Log(b foreach(string b in burgerList));
    }

    private void RecalculateValue() {
      _value = 0;
      foreach (IngredAddScript script in _ingredScripts) {
        _value += script.IngradValue * script.CurrIngredient;
      }
      //WriteConfirm();
    }

    private void WriteConfirm() {
      _confirmText.text = "Confirm: " + _value.ToString();
    }
  }
}
  
