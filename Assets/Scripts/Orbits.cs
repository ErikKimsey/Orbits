using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour
{
    // Start is called before the first frame update
    float dist;
    Star star;
    MeshRenderer planet;
    void Start()
    {
      planet = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
