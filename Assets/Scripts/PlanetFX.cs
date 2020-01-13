using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFX: MonoBehaviour {

  public float speed = 3f;
  public float xRotationRate = 3f;
  public float yRotationRate = -2f;
  public float zRotationRate = 2f;


  private void RotatePlanet(){
     transform.Rotate(new Vector3(xRotationRate, yRotationRate, zRotationRate), 45 * Time.deltaTime * speed);
  }

  private void TiltPlanet(){
    transform.rotation = TiltQuat(Input.gyro.attitude);
  }

  private static Quaternion TiltQuat(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }


  private void Update() {
    // RotatePlanet();
  }
}