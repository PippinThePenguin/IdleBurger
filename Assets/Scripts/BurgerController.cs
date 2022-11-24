using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BurgerNamespace {
  public class BurgerController : MonoBehaviour {
    public static BurgerController Instance;
    [SerializeField] public int _defBurgerHP = 20;    
    [SerializeField] private int _curBurgerHP;
    [SerializeField] private Transform _burgerFather;
    [SerializeField] public int _coinsPerBurger;
    [SerializeField] private Animator _burgerAnimator;
    private ClickController _clickController;
    private Queue<GameObject> _burgerQueue;
    private GameObject _currentBurger;
    private int _biteTreshold;
    private int _currBites;

    private void Awake() {
      Instance = this;
    }
    void Start() {
      _clickController = ClickController.Instance;
      MakeQueue();
      _clickController.OnBurgerBite.AddListener(ProcessBite);
      if (_burgerAnimator != null) {
        //_clickController.OnBurgerBite.AddListener(AnimBite);
      }
      BurgerMenuController.Instance.OnBurgerMenuDisable.AddListener(Remake);
      _curBurgerHP = _defBurgerHP;
      _currBites = 0;
      _biteTreshold = _defBurgerHP / 11;
      Debug.Log("UpdateHP");
      _currentBurger = _burgerQueue.Dequeue();
      _currentBurger.SetActive(true);

    }

    private void AnimBite(int arg0) {
      //_burgerAnimator.Play("Bump");
    }

    private void MakeQueue() {
      _burgerQueue = new Queue<GameObject>();
      foreach (Transform burger in _burgerFather) {
        _burgerQueue.Enqueue(burger.gameObject);
        burger.gameObject.SetActive(false);
      }
    }

    private void GetNextBurger() {
      _burgerQueue.Enqueue(_currentBurger);
      _currentBurger = _burgerQueue.Dequeue();
      _currentBurger.SetActive(true);
    }

    public void Remake() {
      Debug.Log("UpdateHP");
      _curBurgerHP = _defBurgerHP;
      _currBites = 0;
      _biteTreshold = _defBurgerHP / 11;
      BurgerDroper.Instance.NewBurger();
      //GetNextBurger();
    }

    private void ProcessBite(int strength) {
      _curBurgerHP -= strength;
      _currBites += strength;
      if (_curBurgerHP < 0) {
        Debug.Log("Im Dead!");
        BurgerMenuController.Instance.ToBurgerMenu();
        CoinCounter.Instance.AddMoney(_coinsPerBurger);
        _currentBurger.SetActive(false);
        Debug.Log("UpdateHP");
        _curBurgerHP = _defBurgerHP;
        return;
      }
      if (_currBites > _biteTreshold) {
        _currBites = 0;
        BurgerDroper.Instance.BiteBurger();
      }
    }
  }

}
