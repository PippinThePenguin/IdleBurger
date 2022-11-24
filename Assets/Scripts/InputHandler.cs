using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BurgerNamespace {
  public class InputHandler : MonoBehaviour {
    public static InputHandler Instance;
    public BurgerControls Controls;

    public InputActionMap ActionMap;
    public InputAction TapAction;
    void Awake() {
      Instance = this;
      Controls = new BurgerControls();
      ActionMap = Controls.DefaultMap;
      TapAction = Controls.DefaultMap.Tap;
      ActionMap.Enable();
    }


    void Start() {

    }
  }
}
  
