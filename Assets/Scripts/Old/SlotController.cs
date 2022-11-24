using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerNamespace {
  public class SlotController : MonoBehaviour {

    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _machine;
    [SerializeField] private int _price = 70;

    private void Awake() {
      _machine.SetActive(false);
      _buttonText.text = _price.ToString();
    }
    void Start() {
      _button.onClick.AddListener(TryBuy);
    }

    // Update is called once per frame
    void Update() {

    }

    private void TryBuy() {
      if (MoneyCounter.Instance.Buy(_price)) {
        EnableMachine();
        _button.onClick.RemoveListener(TryBuy);
      }
    }

    private void EnableMachine() {
      _machine.SetActive(true);
    }
  }

}
