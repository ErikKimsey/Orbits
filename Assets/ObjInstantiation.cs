using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInstantiation : MonoBehaviour
{
    public GameObject _objectPrefab;
    GameObject[] _sampleObject = new GameObject[512];

    public float _maxScale;

    public float _setEulerAngles = 0.703125f;
    void Start()
    {
      float objLength = _sampleObject.Length;
      for (int i = 0; i < 512; i++){
        GameObject _objInstance = (GameObject) Instantiate(_objectPrefab);
        _objInstance.transform.position = this.transform.position;
        _objInstance.transform.parent = this.transform;
        _objInstance.name = "SampleObj_" + i;
        this.transform.eulerAngles = new Vector3(0, _setEulerAngles * i, 0); 
        _objInstance.transform.position = Vector3.forward * 100;
        _objInstance.transform.rotation = new Quaternion(0,0,0,1);
        _sampleObject[i] = _objInstance;
      }
    }

    // Update is called once per frame
    void Update()
    {
      for (int i = 0; i < 512; i++){
        if(_sampleObject != null){
          _sampleObject[i].transform.localScale = new Vector3(10,(AudioRecorder._audioSamples[i] * _maxScale) + 10, 10);
        }
      } 
    }
}
