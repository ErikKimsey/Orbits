using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
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

    private void CalculateOrbit(){
      CalculateDistance();
       transform.RotateAround(m_Star.GetPosition(), Vector3.up, 30 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      CalculateOrbit();
    }
}
