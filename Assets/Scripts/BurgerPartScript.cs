using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BurgerNamespace {
  public class BurgerPartScript : MonoBehaviour {
    public Animator PartAnimator;
    public int PreFallTime = 1000;
    public Vector3 Height = new Vector3(0, 1, 0);

    public bool HasParts = false;
    public Transform PartsParent;
    [SerializeField] private int _currPart = 0;
    private List<GameObject> _partsList;
    private void OnEnable() {
      if (HasParts) {
        _currPart = 0;
        _partsList = new List<GameObject>();
        PartAnimator.gameObject.SetActive(true);
        foreach (Transform part in PartsParent.transform) {
          _partsList.Add(part.gameObject);
          part.gameObject.SetActive(false);
        }
        StopAllCoroutines();
        StartCoroutine(WaitForAnim());
      }     
    }

    public void GetBite() {
      if (!HasParts) {
        return;
      }
      foreach (Transform part in PartsParent.transform) {
        part.gameObject.SetActive(false);
      }
      _partsList[_currPart].SetActive(true);
      _currPart++;
      _currPart = Mathf.Clamp(_currPart, 0, _partsList.Count - 1);
    }
    public IEnumerator WaitForAnim() {
      while (PartAnimator.GetCurrentAnimatorStateInfo(0).IsName("Falling")) {       
        yield return null;        
      }
      PartAnimator.gameObject.SetActive(false);
      GetBite();
    }

  }

}
