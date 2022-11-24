using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  public class BurgerConstructor : MonoBehaviour {

    public int BurgerValue;

    [SerializeField] private Vector3 _step;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _nextPosition;
    [SerializeField] private LinkedList<Transform> _burgerStack;
    [SerializeField] private int _burgerBaseValue = 1;

    private void OnEnable() {
      BurgerValue = _burgerBaseValue;
      _nextPosition = _startPosition;
      _burgerStack = new LinkedList<Transform>();
    }

    
    private void OnDisable() {
      transform.DetachChildren();
      BurgerValue = 0;
    }

    public IEnumerable<Transform> DisasembleBurger() {
      List<Transform> list = new List<Transform>();
      foreach (Transform t in _burgerStack) {
        list.Add(t);
      }
      transform.DetachChildren();
      return list;
    }
    public void StackBurger(Transform next) {
      next.parent = transform;
      next.localPosition = _nextPosition;
      _nextPosition += _step;
      _burgerStack.AddLast(next);
    }

    public void AddValue(int value) {
      BurgerValue += value;
    }
  }

}
