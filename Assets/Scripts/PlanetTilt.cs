using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTilt: MonoBehaviour {



  private GameObject planet;
  private void TiltPlanet(){
    planet = GetComponent<GameObject>();
    // transform.rotation = TiltQuat(Input.gyro.attitude);
  }

  private static Quaternion TiltQuat(Quaternion q)
    {
      return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

  private void Update() {
    TiltPlanet();
  }

}