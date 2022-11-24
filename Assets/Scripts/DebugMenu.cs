using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BurgerNamespace {
  public class DebugMenu : MonoBehaviour {
    public static DebugMenu Instance;

    [SerializeField] private Transform _menu;
    [SerializeField] private Transform _inGameButton;
    [SerializeField] private TMP_InputField _xCamInput;
    [SerializeField] private TMP_InputField _yCamInput;
    [SerializeField] private TMP_InputField _zCamInput;
    [SerializeField] private TMP_InputField _xRotCamInput;
    [SerializeField] private TMP_InputField _yRotCamInput;
    [SerializeField] private TMP_InputField _zRotCamInput;
    [SerializeField] private TMP_InputField _coinAddInput;
    [SerializeField] private TMP_InputField _moneyAddInput;

    private MoneyCounter _moneyCounter;
    private Camera _camera;

    private Vector3 _defaultCameraPosition;

    private void Start() {
      _moneyCounter = MoneyCounter.Instance;
      _camera = Camera.main;
      _defaultCameraPosition = _camera.transform.position;
      ShrinkDebugMenu();
      WriteInputFields();
    }

    public void OpenDebugMenu() {
      _menu.gameObject.SetActive(true);
      _inGameButton.gameObject.SetActive(false);
    }

    public void ShrinkDebugMenu() {
      _menu.gameObject.SetActive(false);
      _inGameButton.gameObject.SetActive(true);
    }

    public void HideDebug() {
      _menu.gameObject.SetActive(false);
      _inGameButton.gameObject.SetActive(false);
    }

    public void SetMoney(int money) {
      _moneyCounter.CurrentMoney = money;
    }

    public void ChangeCameraPosition() {
      Vector3 posVectror = new Vector3(Convert.ToSingle(_xCamInput.text), Convert.ToSingle(_yCamInput.text), Convert.ToSingle(_zCamInput.text));
      SetCameraPosition(posVectror);      
    }

    private void WriteInputFields() {
      _xCamInput.text = _camera.transform.position.x.ToString();
      _yCamInput.text = _camera.transform.position.y.ToString();
      _zCamInput.text = _camera.transform.position.z.ToString();
    }

    private void SetCameraPosition(Vector3 position) {
      _camera.transform.position = position;
      WriteInputFields();
    }

    public void ReturnCameraDefault() {
      _camera.transform.position = _defaultCameraPosition;
      WriteInputFields();
    }

    public void ChangeCameraRotation() {
      Vector3 rotVectror = new Vector3(Convert.ToSingle(_xRotCamInput.text), Convert.ToSingle(_yRotCamInput.text), Convert.ToSingle(_zRotCamInput.text));
      SetCameraRotation(rotVectror);
    }

    private void WriteInputRotFields() {
      _xRotCamInput.text = _camera.transform.position.x.ToString();
      _yRotCamInput.text = _camera.transform.position.y.ToString();
      _zRotCamInput.text = _camera.transform.position.z.ToString();
    }

    private void SetCameraRotation(Vector3 position) {
      _camera.transform.rotation = Quaternion.EulerRotation(position);
      WriteInputRotFields();
    }

    public void ReturnRotationDefault() {
      _camera.transform.position = _defaultCameraPosition;
      WriteInputRotFields();
    }

    public void AddCoins() {
      CoinCounter.Instance.AddMoney(Convert.ToInt32(_coinAddInput.text));
    }

    public void AddMoney() {
      MoneyCounter.Instance.AddMoney(Convert.ToInt32(_moneyAddInput.text));
    }
  }

}
