using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    
    private MeshRenderer star;

    [SerializeField]
    private Vector3 starPos;
    void Start()
    {
      star = GetComponent<MeshRenderer>();
    }

    public Vector3 GetPosition(){
      return transform.position;
    }
    void Update()
    {
        
    }
}