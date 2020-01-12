using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFX: MonoBehaviour {

  public float speed = 3f;
  private void Update() {
    // transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
     transform.Rotate(Vector3.left, 45 * Time.deltaTime * speed);
  }
}