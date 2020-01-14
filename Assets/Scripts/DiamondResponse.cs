using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondResponse : MonoBehaviour
{
    // Start is called before the first frame update
    public float[] _bands;
    Planet planet;
    AudioRecorder audio;
    void Start()
    {
      planet = GameObject.Find("diamond").GetComponent<Planet>();

      audio = GetComponent<AudioRecorder>();
    }

    // Update is called once per frame
    void Update()
    {
      // Debug.Log(audio._freqBand[7]);
      // Debug.Log(audio._freqBand[6]);
      planet.transform.localScale = new Vector3(audio._freqBand[5] * 10,audio._freqBand[3],audio._freqBand[3]);
    }
}
