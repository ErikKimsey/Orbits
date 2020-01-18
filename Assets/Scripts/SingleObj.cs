using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObj : MonoBehaviour
{

  public int _band;

  public float _scaleStart, _scaleMultiplier;
  private void Start() {
    
  }

  private void Update() {
    for(int i=0; i<AudioRecorder._freqBand.Length; i++){
      // Debug.Log("AudioRecorder._freqBand[" + i + "]");
      // Debug.Log((AudioRecorder._freqBand[_band]) );
    }
    transform.localScale = new Vector3(transform.localScale.x, (_scaleStart + AudioRecorder._freqBand[_band] * _scaleMultiplier), transform.localScale.z);
  }
}