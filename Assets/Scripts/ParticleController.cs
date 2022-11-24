using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerNamespace {
  public class ParticleController : MonoBehaviour {
    [SerializeField] private List<ParticleSystem> _particleSystems;
    private ClickController _clickController;
    void Start() {
      _clickController = ClickController.Instance;
      _clickController.OnBurgerBite.AddListener(PlayParticles);
    }

    private void PlayParticles(int arg0) {
      foreach (ParticleSystem p in _particleSystems) {
        p.Play();
      }
    }
  }
}
  
