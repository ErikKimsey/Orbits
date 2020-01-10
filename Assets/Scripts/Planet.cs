using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    float dist;
    public MeshRenderer planet;
    private Vector3 planetPos;
    public GameObject m_StarGameObj;
    Star m_Star;

    private float distFromStar;

    private Vector3 currPos;

    private float semiMinorAxis;
    private float semiMajorAxis;

    public float eccentricity = 0.7f;


    void Start()
    {
      planet = GetComponent<MeshRenderer>();
      planetPos = transform.position;
      m_StarGameObj = GameObject.Find("Star");
      m_Star = m_StarGameObj.GetComponent<Star>();
      semiMajorAxis = 7.0f;
      semiMinorAxis = 2.0f;
      eccentricity = 0.7f;
    }

    private void CalculateDistance(){
           if (m_Star)
        {
            distFromStar = Vector3.Distance(m_Star.GetPosition(), transform.position);
        }
    }

    private void CalculateEccentricity(){
      eccentricity = (semiMajorAxis - semiMinorAxis) / (semiMinorAxis + semiMajorAxis);
    }

    // private float CalculateKepler(float axis){
    //   return axis * Mathf.Cos(axis - transform.position.x * Time.deltaTime);
    // }
    private float CalculateX(float axis){
      return axis * Mathf.Cos(axis - transform.position.x) * Time.deltaTime;
    }

    /**
      x = major * cos(major - transform.position.x * deltaTime)
      z = minor * sin(minor transform.position.z * deltaTime)
      y = minor * sin(minor transform.position.y * deltaTime)
    */

    private void CalculateCurrentPos(){
      currPos = transform.position;
      float x = CalculateX(semiMajorAxis);
      Debug.Log(x);
    }

    
    private void CalculateOrbit(){
      CalculateDistance();
       transform.RotateAround(m_Star.GetPosition(), Vector3.down, 60 * Time.deltaTime);
       Debug.Log(transform.position);
    }

    void Update()
    {
      // CalculateOrbit();
      transform.position = new Vector3(1f + (9f * Mathf.Sin(Mathf.Deg2Rad * eccentricity)),
      0f + ( 1f * Mathf.Sin(Mathf.Deg2Rad * eccentricity)),
      0f + ( 5f * Mathf.Cos(Mathf.Deg2Rad * eccentricity)));
      // transform.Rotate()
    eccentricity += 5f;
    }
}
