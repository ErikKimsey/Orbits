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

    private float CalculateKepler(float vectorPos){
      return semiMajorAxis * (1 - Mathf.Pow(eccentricity, 2) ) / (1 + eccentricity * Mathf.Cos(vectorPos));
    }

    private void CalculateCurrentPos(){
      currPos = transform.position;
      float x = CalculateKepler(currPos.x);
      float z = CalculateKepler(currPos.z);
      float y = CalculateKepler(currPos.x);
      // transform.position = 
    }

    
    private void CalculateOrbit(){
      CalculateDistance();
       transform.RotateAround(m_Star.GetPosition(), Vector3.down, 60 * Time.deltaTime);
       Debug.Log(transform.position);
    }

    void Update()
    {
      CalculateOrbit();
    }
}
