using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {
  public Slider Slider;
  [SerializeField] private string sceneName;
  // Start is called before the first frame update
  void Start() {
    LoadLvL();
  }
  void LoadLvL() {
    StartCoroutine(AsynchronousLoad(sceneName));
  }
  IEnumerator AsynchronousLoad(string scene) {
    yield return null;
    AsyncOperation ao = SceneManager.LoadSceneAsync(1);
    while (!ao.isDone) {
      float progress = Mathf.Clamp01(ao.progress / 0.9f);
      Slider.value = progress;
      yield return null;
    }
  }
}