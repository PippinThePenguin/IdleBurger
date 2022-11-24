using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BurgerNamespace {
  public class AutoClicker : MonoBehaviour {
    public static AutoClicker Instance;
    public int AutoClickStrength = 1;
    public int AutoClickDelay = 2000;
    [SerializeField] private bool _isClicking = true;
    private ClickController _clickController;
    private MoneyCounter _moneyCounter;
    private BurgerMenuController _burgerMenuController;
    private void Awake() {
      Instance = this;
    }

    private void Start() {
      _clickController = ClickController.Instance;
      _moneyCounter = MoneyCounter.Instance;
      _burgerMenuController = BurgerMenuController.Instance;
      _burgerMenuController.OnBurgerMenuEnable.AddListener(StopClicking);
      //_burgerMenuController.OnBurgerMenuDisable.AddListener(StartClicking);
      
    }    


    public void StartClicking() {
      _isClicking = true;
      StartCoroutine(AutoClick());
    }

    public void StopClicking() {
      _isClicking = false;
      StopAllCoroutines();
    }


    public void ReduceDelay(int newDelay) {
      AutoClickDelay = newDelay;
    }

    public void BetterClick(int newStrength) {
      AutoClickStrength = newStrength;
    }

    private IEnumerator AutoClick() {
      if (_isClicking) {
        _clickController.OnBurgerBite?.Invoke(AutoClickStrength);
        //_moneyCounter.AddMoney(AutoClickStrength);
        //Debug.Log("click!");
        yield return new WaitForSeconds(AutoClickDelay / 1000f);
        StartCoroutine(AutoClick());
      }
      
    }   
  }
}
  
