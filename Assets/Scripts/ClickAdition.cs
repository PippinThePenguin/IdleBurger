using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace BurgerNamespace {
  public class ClickAdition : MonoBehaviour {
    public UnityEvent ClickEvent;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip biteClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<ParticleSystem> particleSystemList = new List<ParticleSystem>();
    [SerializeField] private float pitchVolumeRange = 0.08f;

    // Start is called before the first frame update
    void Start() {
      ClickController.Instance.OnBurgerBite.AddListener(Doit);      
    }


    private void Doit(int int0) {
      audioSource.volume = 1 + Random.Range(-1* pitchVolumeRange, pitchVolumeRange);
      audioSource.pitch = 1 + Random.Range(-1 * pitchVolumeRange, pitchVolumeRange);
      audioSource.PlayOneShot(biteClip);

      animator.Play("Bump");
      foreach (ParticleSystem part in particleSystemList) {
        part.Play();
      }
      ClickEvent?.Invoke();
    }
  }
}
  
