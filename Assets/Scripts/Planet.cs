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

    public float eccentricityIncrement = 1f;

    public float deg = 30.0f;

    public float xAlpha = -2.4f;
    public float yAlpha = 5f;
    public float zAlpha = -6f;

    public float yDeg = 1;


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

    private float CalculateX(float axis){
      return axis * Mathf.Cos(axis - transform.position.x) * Time.deltaTime;
    }

    private void CalculateCurrentPos(){
      currPos = transform.position;
      float x = CalculateX(semiMajorAxis);
    }

    
    private void CalculateOrbit(){
      transform.position = new Vector3(1f + (xAlpha * Mathf.Sin(Mathf.Deg2Rad * eccentricity)),
      yAlpha + ( 1f * Mathf.Sin(yDeg * Mathf.Deg2Rad * eccentricity)),
      1f + ( zAlpha * Mathf.Cos(Mathf.Deg2Rad * eccentricity)));
      eccentricity += eccentricityIncrement;
        float rad = deg * Mathf.Deg2Rad;
        Debug.Log(deg + " degrees are equal to " + rad + " radians.");
    }

    void Update()
    {
      
    }
}
