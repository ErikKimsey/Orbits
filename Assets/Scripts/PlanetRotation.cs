using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation: MonoBehaviour {

  public float speed = 3f;
  public float xRotationRate = 3f;
  public float yRotationRate = -2f;
  public float zRotationRate = 2f;
  private Planet planet;

  private DetectDeviceType device;
  private string deviceType;

  private void Start() {
    planet = GetComponent<Planet>();
    
    device = planet.GetComponent<DetectDeviceType>();
    Debug.Log(device.GetDeviceType());
  }


  private void RotatePlanet(){
     transform.Rotate(new Vector3(xRotationRate, yRotationRate, zRotationRate), 45 * Time.deltaTime * speed);
  }

  private void Update() {
    RotatePlanet();
  }
}