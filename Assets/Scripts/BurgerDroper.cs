using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BurgerNamespace {
  public class BurgerDroper : MonoBehaviour {
    public static BurgerDroper Instance;
    public List<string> BurgerList;
    public List<BurgerPartScript> PartList;
    public Transform Parent;
    [SerializeField] private float _fallSpeed = 1.0f;
    private Pooler _pooler;

    private void Awake() {
      Instance = this;
    }
    void Start() {
      _pooler = Pooler.Singleton;
      CreateBurgerList();
      StartDrop();
    }

    private void CreateBurgerList() {      
      PartList = new List<BurgerPartScript>();
      Vector3 position = Vector3.zero;
      foreach (var part in BurgerList) {
        var pref = _pooler.GetObjectFromPool(part);
        pref.transform.parent = transform;
        pref.transform.localPosition = position;
        var script = pref.GetComponent<BurgerPartScript>();
        position += script.Height;
        PartList.Add(script);
        pref.SetActive(true);
      }
    }

    private async void StartDrop() {
      InputHandler.Instance.ActionMap.Disable();
      AutoClicker.Instance.StopClicking();
      foreach (var part in PartList) {
        await Task.Delay((int)(part.PreFallTime / _fallSpeed));
        part.PartAnimator.SetFloat("FallSpeed", _fallSpeed);       
      }
      while (PartList[PartList.Count - 1].PartAnimator.GetCurrentAnimatorStateInfo(0).IsName("Falling")) {
        await Task.Yield();
      }
      InputHandler.Instance.ActionMap.Enable();
      AutoClicker.Instance.StartClicking();
    }
    public void BiteBurger() {
      foreach (var part in PartList) {
        part.GetBite();
      }
    }

    public void NewBurger() {
      RecicleList();
      CreateBurgerList();
      StartDrop();
    }

    private void RecicleList() {
      foreach (BurgerPartScript part in PartList) {
        //part.gameObject.SetActive(false);
        _pooler.TakeObjectIntoPool(part.gameObject);
      }
    }
  }

}
